using DormAPI.Models.Entities;

namespace DormAPI.Data.Repository.Announcements
{
    public class AnnouncementsRepository : UsersAccessRepository<Announcement>, IAnnouncementsRepository
    {
        public AnnouncementsRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
