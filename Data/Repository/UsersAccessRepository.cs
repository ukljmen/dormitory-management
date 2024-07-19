using DormAPI.Exceptions;
using DormAPI.Models.Entities;
using DormAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace DormAPI.Data.Repository
{
    public class UsersAccessRepository<T> : BaseRepository<T>, IUsersAccessRepository<T> where T : Entity
    {
        public UsersAccessRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<Manager> GetManagerByUserIdAsync(int userId)
        {
            return await _db.Managers
                .FirstOrDefaultAsync(m => m.UserId == userId)
                ?? throw new NotFoundException(typeof(Manager), userId);
        }

        public async Task<Student> GetStudentByUserIdAsync(int userId)
        {
            return await _db.Students
                .FirstOrDefaultAsync(m => m.UserId == userId)
                ?? throw new NotFoundException(typeof(Student), userId);
        }

        public async Task<Conservator> GetConservatorByUserIdAsync(int userId)
        {
            return await _db.Conservators
                .FirstOrDefaultAsync(m => m.UserId == userId)
                ?? throw new NotFoundException(typeof(Conservator), userId);
        }

        public async Task<Manager> GetManagerByPersonIdAsync(int personId)
        {
            return await _db.Managers.FindAsync(personId)
                ?? throw new NotFoundException(typeof(Manager), personId);
        }

        public async Task<Student> GetStudentByPersonIdAsync(int personId)
        {
            return await _db.Students.FindAsync(personId)
                ?? throw new NotFoundException(typeof(Student), personId);
        }

        public async Task<Conservator> GetConservatorByPersonIdAsync(int personId)
        {
            return await _db.Conservators.FindAsync(personId)
                ?? throw new NotFoundException(typeof(Conservator), personId);
        }
    }
}
