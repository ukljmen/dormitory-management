using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.Problems.AssignProblem
{
    public record AssignProblemRequest(
        int ProblemId,
        int ConservatorId) : IRequest<ProblemDto>
    {
    }
}
