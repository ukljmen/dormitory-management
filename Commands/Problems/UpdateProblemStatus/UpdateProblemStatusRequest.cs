using DormAPI.Models.Dto;
using DormAPI.Models.Enums;
using MediatR;

namespace DormAPI.Commands.Problems.UpdateProblemStatus
{
    public record UpdateProblemStatusRequest(
        int ProblemId,
        ProblemStatus Status) : IRequest<ProblemDto>
    {
    }
}
