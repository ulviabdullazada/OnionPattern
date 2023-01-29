using TheCheckpoint.Application.Repostories;
using TheCheckpoint.Domain.Entities;
using TheCheckpoint.Persistance.Contexts;

namespace TheCheckpoint.Persistance.Repostories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(TheCheckpointDbContext context) : base(context)
        {
        }
    }
}