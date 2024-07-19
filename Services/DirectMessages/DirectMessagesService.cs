using AutoMapper;
using Azure.Core;
using DormAPI.Commands.DirectMessages.SendMessage;
using DormAPI.Commands.DirectMessages.UpdateMessage;
using DormAPI.Data.Repository.DirectMessages;
using DormAPI.Exceptions;
using DormAPI.Models.Dto;
using DormAPI.Models.Entities;
using DormAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Services.DirectMessages
{
    public class DirectMessagesService : BaseService, IDirectMessagesService
    {
        private readonly IDirectMessagesRepository _repository;

        public DirectMessagesService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IDirectMessagesRepository repository) : base(mapper, httpContextAccessor)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DirectMessageDto>> GetMessagesAsync(CancellationToken ct)
        {
            var personId = GetPersonIdFromToken();

            List<DirectMessage> result = GetUserRoleFromToken() switch 
            {
                UserRole.Manager or UserRole.Admin => await GetManagersSentMessages(personId),
                UserRole.Student => await GetStudentsReceivedMessages(personId),
                _ => throw new BadRequestException(ErrorMessages.RoleNotAllowed)
            };

            return _mapper.Map<IEnumerable<DirectMessageDto>>(result);
        }

        private Task<List<DirectMessage>> GetManagersSentMessages(int managerId)
        {
            return _repository
                .GetAll()
                .Include(m => m.Manager)
                .Include(m => m.DirectMessageStudents)
                    .ThenInclude(dms => dms.Student)
                .Where(m => m.ManagerId == managerId)
                .OrderByDescending(m => m.AddedTS)
                .ToListAsync();
        }

        private Task<List<DirectMessage>> GetStudentsReceivedMessages(int studentId)
        {
            return _repository
                .GetAll()
                .Include(m => m.Manager)
                .Include(m => m.DirectMessageStudents)
                .Where(m => m.DirectMessageStudents.Any(dms => dms.StudentId == studentId))
                .OrderByDescending(m => m.AddedTS)
                .ToListAsync();
        }

        public async Task<DirectMessageDto> SendMessageAsync(SendMessageRequest request, CancellationToken ct)
        {
            var message = new DirectMessage()
            {
                Title = request.Title,
                Content = request.Content,
                ManagerId = GetPersonIdFromToken(),
                DirectMessageStudents = request.ReceiverIds
                    .Select(receiverId => new DirectMessageStudent()
                    {
                        StudentId = receiverId
                    }).ToList()
            };

            _repository.Create(message);
            await _repository.CommitAsync(ct);

            return _mapper.Map<DirectMessageDto>(message);
        }

        public async Task<DirectMessageDto> UpdateMessageAsync(UpdateMessageRequest request, CancellationToken ct)
        {
            var messageId = request.MessageId;

            var message = await _repository
                .GetAll()
                .Include(m => m.DirectMessageStudents)
                .FirstOrDefaultAsync(m => m.Id == request.MessageId)
                ?? throw new NotFoundException(typeof(DirectMessage), messageId);

            message.Title = request.Title; 
            message.Content = request.Content;
            message.DirectMessageStudents
                .ForEach(dms =>
                {
                    dms.IsRead = false;
                });

            _repository.Update(message);
            await _repository.CommitAsync(ct);

            return _mapper.Map<DirectMessageDto>(message);
        }

        public async Task<DirectMessageDto> DeleteMessageAsync(int messageId, CancellationToken ct)
        {
            var message = await _repository
                .GetByIdAsync(messageId)
                ?? throw new NotFoundException(typeof(DirectMessage), messageId);

            _repository.Delete(message);
            await _repository.CommitAsync(ct);

            return _mapper.Map<DirectMessageDto>(message);
        }
    }
}
