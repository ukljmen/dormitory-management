using AutoMapper;
using DormAPI.Data.Repository.Floors;
using DormAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Services.Floors
{
    public class FloorsService : BaseService, IFloorsService
    {
        private readonly IFloorsRepository _repository;

        public FloorsService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IFloorsRepository repository)
            : base(mapper, httpContextAccessor)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FloorDto>> GetFloorsAsync(CancellationToken ct)
        {
            var floors = await _repository
                .GetAll()
                .Include(f => f.Rooms)
                    .ThenInclude(r => r.Students)
                .ToListAsync();

            return _mapper.Map<List<FloorDto>>(floors);
        }
    }
}
