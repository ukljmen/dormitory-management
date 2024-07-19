using DormAPI.Commands.DirectMessages.SendMessage;
using DormAPI.Commands.DirectMessages.UpdateMessage;
using DormAPI.Models.Dto;

namespace DormAPI.Services.DirectMessages
{
    public interface IDirectMessagesService
    {
        public Task<IEnumerable<DirectMessageDto>> GetMessagesAsync(CancellationToken ct);
        public Task<DirectMessageDto> SendMessageAsync(SendMessageRequest request, CancellationToken ct);
        public Task<DirectMessageDto> UpdateMessageAsync(UpdateMessageRequest request, CancellationToken ct);
        public Task<DirectMessageDto> DeleteMessageAsync(int messageId, CancellationToken ct);
    }
}
