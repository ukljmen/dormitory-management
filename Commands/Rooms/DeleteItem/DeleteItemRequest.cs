using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.Rooms.DeleteItem
{
    public record DeleteItemRequest(int ItemId) : IRequest<ItemDto>
    {
    }
}
