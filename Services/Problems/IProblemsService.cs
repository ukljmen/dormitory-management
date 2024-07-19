using DormAPI.Commands.Problems.AssignProblem;
using DormAPI.Commands.Problems.ReportProblem;
using DormAPI.Commands.Problems.UpdateProblemStatus;
using DormAPI.Models.Dto;

namespace DormAPI.Services.Problems
{
    public interface IProblemsService
    {
        public Task<IEnumerable<ProblemDto>> GetProblemsAsync();

        public Task<ProblemDto> ReportProblemAsync(ReportProblemRequest request, CancellationToken ct);
        public Task<ProblemDto> AssignProblemAsync(AssignProblemRequest request, CancellationToken ct);
        public Task<ProblemDto> UpdateProblemStatusAsync(UpdateProblemStatusRequest request, CancellationToken ct);
    }
}
