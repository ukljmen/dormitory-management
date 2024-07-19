using DormAPI.Exceptions;
using DormAPI.Models.Entities;
using DormAPI.Models.Enums;

namespace DormAPI.Data.Repository
{
    public interface IUsersAccessRepository<T> : IBaseRepository<T> where T : Entity
    {
        public Task<Manager> GetManagerByUserIdAsync(int userId);

        public Task<Student> GetStudentByUserIdAsync(int userId);

        public Task<Conservator> GetConservatorByUserIdAsync(int userId);

        public Task<Manager> GetManagerByPersonIdAsync(int personId);

        public Task<Student> GetStudentByPersonIdAsync(int personId);

        public Task<Conservator> GetConservatorByPersonIdAsync(int personId);
    }
}
