using AutoMapper;
using DormAPI.Commands.Rooms.AddItem;
using DormAPI.Commands.Rooms.UpdateItem;
using DormAPI.Data.Repository.Items;
using DormAPI.Data.Repository.Rooms;
using DormAPI.Exceptions;
using DormAPI.Models.Dto;
using DormAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Services.Rooms
{
    public class RoomsService : BaseService, IRoomsService
    {
        private readonly IRoomsRepository _roomsRepository;
        private readonly IItemsRepository _itemsRepository;

        public RoomsService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IRoomsRepository roomsRepository,
            IItemsRepository itemsRepository) : base(mapper, httpContextAccessor)
        {
            _roomsRepository = roomsRepository;
            _itemsRepository = itemsRepository;
        }

        public async Task<ItemDto> AddItemAsync(AddItemRequest request, CancellationToken ct)
        {
            var room = await _roomsRepository
                .GetByIdAsync(request.RoomId)
                ?? throw new NotFoundException(typeof(Room), request.RoomId);

            var item = new Item()
            {
                Name = request.Name,
                RoomId = request.RoomId
            };

            _itemsRepository.Create(item);
            await _itemsRepository.CommitAsync(ct);

            return _mapper.Map<ItemDto>(item);
        }

        public async Task<ItemDto> DeleteItemAsync(int itemId, CancellationToken ct)
        {
            var item = await _itemsRepository
                .GetByIdAsync(itemId)
                ?? throw new NotFoundException(typeof(Item), itemId);

            _itemsRepository.Delete(item);
            await _itemsRepository.CommitAsync(ct);

            return _mapper.Map<ItemDto>(item);
        }

        public async Task<RoomDto> GetRoomAsync(int roomId)
        {
            var room = await _roomsRepository
                .GetAll()
                .Include(r => r.Students)
                    .ThenInclude(s => s.Problems)
                        .ThenInclude(p => p.Item)
                .Include(r => r.Items)
                .FirstOrDefaultAsync(r => r.Id == roomId)
                ?? throw new NotFoundException(typeof(Room), roomId);

            return _mapper.Map<RoomDto>(room);
        }

        public async Task<RoomDto> GetRoomByStudentIdAsync(int studentId, CancellationToken ct)
        {
            var room = await _roomsRepository
                .GetAll()
                .Include(r => r.Students)
                    .ThenInclude(s => s.Problems)
                        .ThenInclude(p => p.Item)
                .Include(r => r.Items)
                .FirstOrDefaultAsync(r => r.Students.Any(s => s.Id == studentId))
                ?? throw new NotFoundException(typeof(Student), studentId);

            return _mapper.Map<RoomDto>(room);
        }

        public async Task<ItemDto> UpdateItemAsync(UpdateItemRequest request, CancellationToken ct)
        {
            var item = await _itemsRepository
                .GetByIdAsync(request.ItemId)
                ?? throw new NotFoundException(typeof(Item), request.ItemId);

            item.Name = request.Name;

            _itemsRepository.Update(item);
            await _itemsRepository.CommitAsync(ct);

            return _mapper.Map<ItemDto>(item);
        }
    }
}
