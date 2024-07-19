using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.Rooms.AddItem
{
    public record AddItemRequest(
        string Name,
        int RoomId) : IRequest<ItemDto>
    {
    }
}
