using DormAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Data.Repository.Rooms
{
    public class RoomsRepository : UsersAccessRepository<Room>, IRoomsRepository
    {
        public RoomsRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
