using DormAPI.Models.Dto;
using DormAPI.Services.Rooms;
using MediatR;

namespace DormAPI.Queries.GetRoomByStudentId
{
    public class GetRoomByStudentIdQueryHandler : IRequestHandler<GetRoomByStudentIdQuery, RoomDto>
    {
        private readonly IRoomsService _roomsService;

        public GetRoomByStudentIdQueryHandler(IRoomsService roomsService)
        {
            _roomsService = roomsService;
        }

        public Task<RoomDto> Handle(GetRoomByStudentIdQuery request, CancellationToken cancellationToken)
        {
            return _roomsService.GetRoomByStudentIdAsync(request.StudentId, cancellationToken);
        }
    }
}
