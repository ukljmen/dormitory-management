using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Queries.GetConservators
{
    public record GetConservatorsQuery : IRequest<IEnumerable<DtoNameId>>
    {
    }
}
