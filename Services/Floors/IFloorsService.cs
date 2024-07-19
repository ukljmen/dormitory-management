using DormAPI.Models.Dto;

namespace DormAPI.Services.Floors
{
    public interface IFloorsService
    {
        public Task<IEnumerable<FloorDto>> GetFloorsAsync(CancellationToken ct);
    }
}
