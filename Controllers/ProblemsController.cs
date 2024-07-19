using AutoMapper.Internal.Mappers;
using DormAPI.Attributes;
using DormAPI.Commands.Problems.AssignProblem;
using DormAPI.Commands.Problems.ReportProblem;
using DormAPI.Commands.Problems.UpdateProblemStatus;
using DormAPI.Models.Dto;
using DormAPI.Queries.GetConservators;
using DormAPI.Queries.GetProblems;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProblemsController : HandleErrorController<ProblemsController>
    {
        public ProblemsController(
            ISender sender, 
            ILogger<ProblemsController> logger) : base(sender, logger)
        {
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ProblemDto[]), 200)]
        public async Task<IActionResult> GetProblemsAsync()
        {
            return await SendRequestAsync(new GetProblemsQuery());
        }

        [Authorize]
        [HttpGet("Conservators")]
        [ProducesResponseType(typeof(DtoNameId[]), 200)]
        public async Task<IActionResult> GetConservatorsAsync()
        {
            return await SendRequestAsync(new GetConservatorsQuery());
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Student)]
        [HttpPost]
        [ProducesResponseType(typeof(ProblemDto), 200)]
        public async Task<IActionResult> ReportProblemAsync(ReportProblemRequest request)
        {
            return await SendRequestAsync(request);
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Manager)]
        [HttpPatch("Assign")]
        [ProducesResponseType(typeof(ProblemDto), 200)]
        public async Task<IActionResult> AssignProblemAsync(AssignProblemRequest request)
        {
            return await SendRequestAsync(request);
        }

        [Authorize]
        [HttpPatch("ChangeStatus")]
        [CheckRole(Models.Enums.UserRole.Manager, Models.Enums.UserRole.Conservator)]
        [ProducesResponseType(typeof(ProblemDto), 200)]
        public async Task<IActionResult> ChangeProblemStatusAsync(UpdateProblemStatusRequest request)
        {
            return await SendRequestAsync(request);
        }
    }
}
