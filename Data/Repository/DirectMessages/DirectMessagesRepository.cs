using DormAPI.Models.Entities;

namespace DormAPI.Data.Repository.DirectMessages
{
    public class DirectMessagesRepository : UsersAccessRepository<DirectMessage>, IDirectMessagesRepository
    {
        public DirectMessagesRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
