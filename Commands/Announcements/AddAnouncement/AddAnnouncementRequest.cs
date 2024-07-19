using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.Announcements.AddAnouncement
{
    public record AddAnnouncementRequest : IRequest<AnnouncementDto>
    {
        public string Title { get; init; }

        public string Content { get; init; }
    }
}
