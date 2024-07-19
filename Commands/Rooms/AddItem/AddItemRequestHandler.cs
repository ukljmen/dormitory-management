using DormAPI.Models.Dto;
using DormAPI.Services.Rooms;
using MediatR;

namespace DormAPI.Commands.Rooms.AddItem
{
    public class AddItemRequestHandler : IRequestHandler<AddItemRequest, ItemDto>
    {
        private readonly IRoomsService _service;

        public AddItemRequestHandler(IRoomsService service)
        {
            _service = service;
        }

        public Task<ItemDto> Handle(AddItemRequest request, CancellationToken cancellationToken)
        {
            return _service.AddItemAsync(request, cancellationToken);
        }
    }
}
