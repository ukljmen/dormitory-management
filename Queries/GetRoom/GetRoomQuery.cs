using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Queries.GetRoom
{
    public record GetRoomQuery(int Id) : IRequest<RoomDto>
    {
    }
}
