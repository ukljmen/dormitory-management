using DormAPI.Models.Entities;

namespace DormAPI.Data.Repository.Floors
{
    public class FloorsRepository : UsersAccessRepository<Floor>, IFloorsRepository
    {
        public FloorsRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
