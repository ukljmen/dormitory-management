using DormAPI.Models.Dto;
using DormAPI.Services.Announcements;
using MediatR;

namespace DormAPI.Queries.GetAnnouncements
{
    public class GetAnnouncementsQueryHandler : IRequestHandler<GetAnnouncementsQuery, IEnumerable<AnnouncementDto>>
    {
        private readonly IAnnouncementsService _service;

        public GetAnnouncementsQueryHandler(IAnnouncementsService service)
        {
            _service = service;
        }

        public Task<IEnumerable<AnnouncementDto>> Handle(GetAnnouncementsQuery request, CancellationToken cancellationToken)
        {
            return _service.GetAnnouncementsAsync(cancellationToken);
        }
    }
}
