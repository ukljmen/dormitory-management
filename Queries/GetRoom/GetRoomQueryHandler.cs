using DormAPI.Models.Dto;
using DormAPI.Services.Rooms;
using MediatR;

namespace DormAPI.Queries.GetRoom
{
    public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, RoomDto>
    {
        private readonly IRoomsService _service;

        public GetRoomQueryHandler(IRoomsService service)
        {
            _service = service;
        }

        public Task<RoomDto> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            return _service.GetRoomAsync(request.Id);
        }
    }
}
