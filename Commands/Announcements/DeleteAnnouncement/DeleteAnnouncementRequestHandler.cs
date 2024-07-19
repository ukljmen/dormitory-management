using DormAPI.Commands.Announcements.AddAnouncement;
using DormAPI.Models.Dto;
using DormAPI.Services.Announcements;
using MediatR;

namespace DormAPI.Commands.Announcements.DeleteAnnouncement
{
    public class DeleteAnnouncementRequestHandler
        : IRequestHandler<DeleteAnnouncementRequest, AnnouncementDto>
    {
        private readonly IAnnouncementsService _service;

        public DeleteAnnouncementRequestHandler(IAnnouncementsService service)
        {
            _service = service;
        }

        public Task<AnnouncementDto> Handle(DeleteAnnouncementRequest request, CancellationToken cancellationToken)
        {
            return _service.DeleteAnnouncementAsync(request, cancellationToken);
        }
    }
}
