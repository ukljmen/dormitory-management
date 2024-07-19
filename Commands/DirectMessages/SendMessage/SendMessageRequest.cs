using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.DirectMessages.SendMessage
{
    public record SendMessageRequest : IRequest<DirectMessageDto>
    {
        public string Title { get; init; } = default!;
        public string Content { get; init; } = default!;

        public IEnumerable<int> ReceiverIds { get; init; } = default!;
    }
}
