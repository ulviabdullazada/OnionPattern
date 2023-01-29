using TheCheckpoint.Application.Repostories;
using TheCheckpoint.Domain.Entities;
using TheCheckpoint.Persistance.Contexts;

namespace TheCheckpoint.Persistance.Repostories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(TheCheckpointDbContext context) : base(context)
        {
        }
    }
}
