using DormAPI.Models.Dto;
using DormAPI.Services.Problems;
using MediatR;

namespace DormAPI.Commands.Problems.ReportProblem
{
    public class ReportProblemRequestHandler : IRequestHandler<ReportProblemRequest, ProblemDto>
    {
        private readonly IProblemsService _service;

        public ReportProblemRequestHandler(IProblemsService service)
        {
            _service = service;
        }

        public Task<ProblemDto> Handle(ReportProblemRequest request, CancellationToken cancellationToken)
        {
            return _service.ReportProblemAsync(request, cancellationToken);
        }
    }
}
