using DormAPI.Models.Entities;

namespace DormAPI.Data.Repository.Items
{
    public class ItemsRepository : UsersAccessRepository<Item>, IItemsRepository
    {
        public ItemsRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
