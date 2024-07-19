using DormAPI.Models.Dto;
using DormAPI.Services.Floors;
using MediatR;

namespace DormAPI.Queries.GetFloors
{
    public class GetFloorsQueryHandler : IRequestHandler<GetFloorsQuery, IEnumerable<FloorDto>>
    {
        private readonly IFloorsService _service;

        public GetFloorsQueryHandler(IFloorsService service)
        {
            _service = service;
        }

        public Task<IEnumerable<FloorDto>> Handle(GetFloorsQuery request, CancellationToken cancellationToken)
        {
            return _service.GetFloorsAsync(cancellationToken);
        }
    }
}
