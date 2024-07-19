using AutoMapper;
using DormAPI.Commands.Problems.AssignProblem;
using DormAPI.Commands.Problems.ReportProblem;
using DormAPI.Commands.Problems.UpdateProblemStatus;
using DormAPI.Data.Repository.Items;
using DormAPI.Data.Repository.Problems;
using DormAPI.Exceptions;
using DormAPI.Models.Dto;
using DormAPI.Models.Entities;
using DormAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Services.Problems
{
    public class ProblemsService : BaseService, IProblemsService
    {
        private readonly IProblemsRepository _problemsRepository;
        private readonly IItemsRepository _itemsRepository;

        public ProblemsService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IProblemsRepository problemsRepository,
            IItemsRepository itemsRepository) : base(mapper, httpContextAccessor)
        {
            _problemsRepository = problemsRepository;
            _itemsRepository = itemsRepository;
        }

        public async Task<ProblemDto> AssignProblemAsync(AssignProblemRequest request, CancellationToken ct)
        {
            var problem = await _problemsRepository
                .GetByIdAsync(request.ProblemId)
                ?? throw new NotFoundException(typeof(Problem), request.ProblemId);

            var conservator = await _problemsRepository
                .GetConservatorByPersonIdAsync(request.ConservatorId);

            problem.ConservatorId = conservator.Id;
            problem.ProblemState = ProblemStatus.Assigned;

            _problemsRepository.Update(problem);
            await _problemsRepository.CommitAsync(ct);

            return _mapper.Map<ProblemDto>(problem);
        }

        public async Task<IEnumerable<ProblemDto>> GetProblemsAsync()
        {
            var personId = GetPersonIdFromToken();

            List<Problem> result = GetUserRoleFromToken() switch
            {
                UserRole.Conservator => await GetConservatorsProblems(personId),
                UserRole.Student => await GetStudentsProblems(personId),
                _ => await GetManagersProblems()
            };

            return _mapper.Map<IEnumerable<ProblemDto>>(result);
        }

        private Task<List<Problem>> GetManagersProblems()
        {
            return _problemsRepository
                .GetAll()
                .Include(p => p.Conservator)
                .Include(p => p.Item)
                .Where(p => p.ProblemState != ProblemStatus.Resolved)
                .ToListAsync();
        }

        private Task<List<Problem>> GetConservatorsProblems(int conservatorId)
        {
            return _problemsRepository
                .GetAll()
                .Include(p => p.Conservator)
                .Include(p => p.Item)
                .Where(p => p.ConservatorId == conservatorId)
                .ToListAsync();
        }

        private Task<List<Problem>> GetStudentsProblems(int studentId)
        {
            return _problemsRepository
                .GetAll()
                .Include(p => p.Conservator)
                .Include(p => p.Item)
                .Where(p => p.StudentId == studentId 
                    && p.ProblemState != ProblemStatus.Resolved)
                .ToListAsync();
        }

        public async Task<ProblemDto> ReportProblemAsync(ReportProblemRequest request, CancellationToken ct)
        {
            if (request?.ItemId != null)
            {
                var item = await _itemsRepository
                    .GetAll()
                    .Include(i => i.Problems)
                    .FirstOrDefaultAsync(i => i.Id == request.ItemId)
                    ?? throw new NotFoundException(typeof(Item), (int)request.ItemId);

                if(item.Problems.Any(p => p.ProblemState != ProblemStatus.Resolved))
                {
                    throw new BadRequestException(ErrorMessages.ProblemAlreadyReported);
                }
            }

            var problem = new Problem()
            {
                Description = request.Description,
                StudentId = GetPersonIdFromToken(),
                ItemId = request?.ItemId,
                ProblemState = ProblemStatus.Sent
            };

            _problemsRepository.Create(problem);
            await _problemsRepository.CommitAsync(ct);

            return _mapper.Map<ProblemDto>(problem);
        }

        public async Task<ProblemDto> UpdateProblemStatusAsync(UpdateProblemStatusRequest request, CancellationToken ct)
        {
            var problem = await _problemsRepository
                .GetByIdAsync(request.ProblemId);

            if(request.Status == Models.Enums.ProblemStatus.Resolved)
            {
                problem.ConservatorId = null;
            }

            problem.ProblemState = request.Status;

            _problemsRepository.Update(problem);
            await _problemsRepository.CommitAsync(ct);

            return _mapper.Map<ProblemDto>(problem);
        }
    }
}
