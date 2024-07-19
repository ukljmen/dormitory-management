using DormAPI.Commands.Rooms.AddItem;
using DormAPI.Commands.Rooms.UpdateItem;
using DormAPI.Models.Dto;

namespace DormAPI.Services.Rooms
{
    public interface IRoomsService
    {
        public Task<RoomDto> GetRoomAsync(int roomId);
        public Task<RoomDto> GetRoomByStudentIdAsync(int studentId, CancellationToken ct);

        public Task<ItemDto> AddItemAsync(AddItemRequest request, CancellationToken ct);
        public Task<ItemDto> UpdateItemAsync(UpdateItemRequest request, CancellationToken ct);
        public Task<ItemDto> DeleteItemAsync(int itemId, CancellationToken ct);
    }
}
