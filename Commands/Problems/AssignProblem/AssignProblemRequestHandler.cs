using DormAPI.Models.Dto;
using DormAPI.Services.Problems;
using MediatR;

namespace DormAPI.Commands.Problems.AssignProblem
{
    public class AssignProblemRequestHandler
        : IRequestHandler<AssignProblemRequest, ProblemDto>
    {
        private readonly IProblemsService _service;

        public AssignProblemRequestHandler(IProblemsService service)
        {
            _service = service;
        }

        public Task<ProblemDto> Handle(AssignProblemRequest request, CancellationToken cancellationToken)
        {
            return _service.AssignProblemAsync(request, cancellationToken);
        }
    }
}
