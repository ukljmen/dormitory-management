using DormAPI.Models.Dto;
using DormAPI.Services.Announcements;
using MediatR;

namespace DormAPI.Commands.Announcements.AddAnouncement
{
    public class AddAnnouncementRequestHandler
        : IRequestHandler<AddAnnouncementRequest, AnnouncementDto>
    {
        private readonly IAnnouncementsService _service;

        public AddAnnouncementRequestHandler(IAnnouncementsService service)
        {
            _service = service;
        }

        public Task<AnnouncementDto> Handle(AddAnnouncementRequest request, CancellationToken cancellationToken)
        {
            return _service.AddAnnouncementAsync(request, cancellationToken);
        }
    }
}
