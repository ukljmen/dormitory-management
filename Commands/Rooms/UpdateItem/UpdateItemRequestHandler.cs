using DormAPI.Models.Dto;
using DormAPI.Services.Rooms;
using MediatR;

namespace DormAPI.Commands.Rooms.UpdateItem
{
    public class UpdateItemRequestHandler : IRequestHandler<UpdateItemRequest, ItemDto>
    {
        private readonly IRoomsService _service;

        public UpdateItemRequestHandler(IRoomsService service)
        {
            _service = service;
        }

        public Task<ItemDto> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
        {
            return _service.UpdateItemAsync(request, cancellationToken);
        }
    }
}
