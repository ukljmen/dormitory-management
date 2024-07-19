using DormAPI.Models.Entities;

namespace DormAPI.Data.Repository
{
    public interface IBaseRepository<T> where T : Entity
    {
        public IQueryable<T> GetAll();
        public IQueryable<T> GetByQuery(Func<T, bool> predicate);
        public ValueTask<T> GetByIdAsync(int id);

        public T Create(T entity);
        public T Update(T entity);
        public T Delete(T entity);

        public Task<int> CommitAsync(CancellationToken ct = default);
    }
}
