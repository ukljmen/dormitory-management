using DormAPI.Commands.Announcements.AddAnouncement;
using DormAPI.Commands.Announcements.DeleteAnnouncement;
using DormAPI.Commands.Announcements.UpdateAnnouncement;
using DormAPI.Models.Dto;

namespace DormAPI.Services.Announcements
{
    public interface IAnnouncementsService
    {
        public Task<IEnumerable<AnnouncementDto>> GetAnnouncementsAsync(CancellationToken ct);
        public Task<AnnouncementDto> AddAnnouncementAsync(AddAnnouncementRequest request, CancellationToken ct);
        public Task<AnnouncementDto> UpdateAnnouncementAsync(UpdateAnnouncementRequest request, CancellationToken ct);
        public Task<AnnouncementDto> DeleteAnnouncementAsync(DeleteAnnouncementRequest request, CancellationToken ct);
    }
}
