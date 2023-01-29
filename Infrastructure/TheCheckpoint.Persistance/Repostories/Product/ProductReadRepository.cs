using TheCheckpoint.Application.Repostories;
using TheCheckpoint.Domain.Entities;
using TheCheckpoint.Persistance.Contexts;

namespace TheCheckpoint.Persistance.Repostories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(TheCheckpointDbContext context) : base(context)
        {
        }
    }
}
