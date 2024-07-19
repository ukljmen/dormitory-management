using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Queries.GetRoomByStudentId
{
    public record GetRoomByStudentIdQuery(int StudentId)
        : IRequest<RoomDto>
    {
    }
}
