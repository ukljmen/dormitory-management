using DormAPI.Models.Dto;
using DormAPI.Services.Rooms;
using MediatR;

namespace DormAPI.Commands.Rooms.DeleteItem
{
    public class DeleteItemRequestHandler : IRequestHandler<DeleteItemRequest, ItemDto>
    {
        private readonly IRoomsService _service;

        public DeleteItemRequestHandler(IRoomsService service)
        {
            _service = service;
        }

        public Task<ItemDto> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
        {
            return _service.DeleteItemAsync(request.ItemId, cancellationToken);
        }
    }
}
