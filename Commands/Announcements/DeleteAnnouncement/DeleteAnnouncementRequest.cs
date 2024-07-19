using DormAPI.Models.Dto;
using MediatR;

namespace DormAPI.Commands.Announcements.DeleteAnnouncement
{
    public record DeleteAnnouncementRequest : IRequest<AnnouncementDto>
    {
        public int Id { get; init; }

        public DeleteAnnouncementRequest(int id)
        {
            Id = id;
        }
    }
}
