using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Queries.GetAnnouncements
{
    public record GetAnnouncementsQuery : IRequest<IEnumerable<AnnouncementDto>>
    {
    }
}
