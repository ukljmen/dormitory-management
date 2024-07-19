using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Queries.GetMessages
{
    public record GetMessagesQuery : IRequest<IEnumerable<DirectMessageDto>>
    {
    }
}
