using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Queries.GetFloors
{
    public record GetFloorsQuery() : IRequest<IEnumerable<FloorDto>>
    {
    }
}
