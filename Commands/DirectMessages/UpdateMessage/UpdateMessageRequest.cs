using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.DirectMessages.UpdateMessage
{
    public record UpdateMessageRequest(
        int MessageId,
        string Title,
        string Content) : IRequest<DirectMessageDto>
    {
    }
}
