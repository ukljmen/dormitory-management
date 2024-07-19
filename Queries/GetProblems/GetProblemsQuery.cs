using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Queries.GetProblems
{
    public record GetProblemsQuery : IRequest<IEnumerable<ProblemDto>>
    {
    }
}
