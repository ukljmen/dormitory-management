using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.Rooms.UpdateItem
{
    public record UpdateItemRequest(
        int ItemId,
        string Name) : IRequest<ItemDto>
    {
    }
}
