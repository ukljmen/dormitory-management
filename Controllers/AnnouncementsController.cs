using Azure;
using DormAPI.Attributes;
using DormAPI.Commands.Announcements.AddAnouncement;
using DormAPI.Commands.Announcements.DeleteAnnouncement;
using DormAPI.Commands.Announcements.UpdateAnnouncement;
using DormAPI.Models.Dto;
using DormAPI.Queries.GetAnnouncements;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DormAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementsController : HandleErrorController<AnnouncementsController>
    {
        public AnnouncementsController(ISender sender, ILogger<AnnouncementsController> logger)
            : base(sender, logger)
        {
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(AnnouncementDto[]), 200)]
        public async Task<IActionResult> GetAnnouncements()
        {
            return await SendRequestAsync(new GetAnnouncementsQuery());
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Manager)]
        [HttpPost]
        public async Task<IActionResult> CreateAnnouncements(AddAnnouncementRequest request)
        {
            return await SendRequestAsync(request);
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Manager)]
        [HttpPut]
        public async Task<IActionResult> UpdateAnnouncement(UpdateAnnouncementRequest request)
        {
            return await SendRequestAsync(request);
        }

        [Authorize]
        [CheckRole(Models.Enums.UserRole.Manager)]
        [HttpDelete]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            return await SendRequestAsync(new DeleteAnnouncementRequest(id));
        }
    }
}
