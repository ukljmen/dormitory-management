using DormAPI.Models.Dto;
using DormAPI.Services.Problems;
using MediatR;

namespace DormAPI.Commands.Problems.UpdateProblemStatus
{
    public class UpdateProblemStatusRequestHandler
        : IRequestHandler<UpdateProblemStatusRequest, ProblemDto>
    {
        private readonly IProblemsService _service;

        public UpdateProblemStatusRequestHandler(IProblemsService service)
        {
            _service = service;
        }

        public Task<ProblemDto> Handle(UpdateProblemStatusRequest request, CancellationToken cancellationToken)
        {
            return _service.UpdateProblemStatusAsync(request, cancellationToken);
        }
    }
}
