using TheCheckpoint.Application.Repostories;
using TheCheckpoint.Domain.Entities;
using TheCheckpoint.Persistance.Contexts;

namespace TheCheckpoint.Persistance.Repostories
{ 
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(TheCheckpointDbContext context) : base(context)
        {
        }
    }
}
