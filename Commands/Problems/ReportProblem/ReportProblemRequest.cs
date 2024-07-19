using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.Problems.ReportProblem
{
    public record ReportProblemRequest(
        string Description,
        int? ItemId) : IRequest<ProblemDto>
    {
    }
}
