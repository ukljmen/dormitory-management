using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.DirectMessages.DeleteMessage
{
    public record DeleteMessageRequest(int MessageId) : IRequest<DirectMessageDto>
    {
    }
}
