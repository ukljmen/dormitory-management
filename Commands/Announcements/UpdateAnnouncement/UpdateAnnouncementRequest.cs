using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.Announcements.UpdateAnnouncement
{
    public record UpdateAnnouncementRequest : IRequest<AnnouncementDto>
    {
        public int Id { get; init; }
        public string Title { get; init; }

        public string Content { get; init; }
    }
}
