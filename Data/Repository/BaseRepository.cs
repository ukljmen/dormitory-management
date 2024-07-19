using DormAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DormAPI.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _db;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>();
        }

        public ValueTask<T> GetByIdAsync(int id)
        {
            return _db.Set<T>()
                .FindAsync(id)!;
        }

        public IQueryable<T> GetByQuery(Func<T, bool> predicate)
        {
            return _db.Set<T>()
                .Where(predicate)
                .AsQueryable();
        }

        public T Create(T entity)
        {
            return _db.Set<T>()
                .Add(entity)
                .Entity;
        }

        public T Update(T entity)
        {
            return _db.Set<T>()
                .Update(entity)
                .Entity;
        }

        public T Delete(T entity)
        {
            return _db.Set<T>()
                .Remove(entity)
                .Entity;
        }

        public Task<int> CommitAsync(CancellationToken ct = default)
        {
            return _db.SaveChangesAsync(ct);
        }
    }
}
