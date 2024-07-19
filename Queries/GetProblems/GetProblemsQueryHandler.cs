using DormAPI.Models.Dto;
using DormAPI.Services.Problems;
using MediatR;

namespace DormAPI.Queries.GetProblems
{
    public class GetProblemsQueryHandler : IRequestHandler<GetProblemsQuery, IEnumerable<ProblemDto>>
    {
        private readonly IProblemsService _service;

        public GetProblemsQueryHandler(IProblemsService service)
        {
            _service = service;
        }

        public Task<IEnumerable<ProblemDto>> Handle(GetProblemsQuery request, CancellationToken cancellationToken)
        {
            return _service.GetProblemsAsync();
        }
    }
}
