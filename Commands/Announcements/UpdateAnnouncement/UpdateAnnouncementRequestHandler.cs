using DormAPI.Commands.Announcements.AddAnouncement;
using DormAPI.Models.Dto;
using DormAPI.Services.Announcements;
using MediatR;

namespace DormAPI.Commands.Announcements.UpdateAnnouncement
{
    public class UpdateAnnouncementRequestHandler
        : IRequestHandler<UpdateAnnouncementRequest, AnnouncementDto>
    {
        private readonly IAnnouncementsService _service;

        public UpdateAnnouncementRequestHandler(IAnnouncementsService service)
        {
            _service = service;
        }

        public Task<AnnouncementDto> Handle(UpdateAnnouncementRequest request, CancellationToken cancellationToken)
        {
            return _service.UpdateAnnouncementAsync(request, cancellationToken);
        }
    }
}
