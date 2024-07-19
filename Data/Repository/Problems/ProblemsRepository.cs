using DormAPI.Models.Entities;

namespace DormAPI.Data.Repository.Problems
{
    public class ProblemsRepository : UsersAccessRepository<Problem>, IProblemsRepository
    {
        public ProblemsRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
