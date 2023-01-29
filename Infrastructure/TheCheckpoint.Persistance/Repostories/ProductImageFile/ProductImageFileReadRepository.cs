using TheCheckpoint.Application.Repostories;
using TheCheckpoint.Domain.Entities;
using TheCheckpoint.Persistance.Contexts;

namespace TheCheckpoint.Persistance.Repostories
{
    public class ProductImageFileReadRepository : ReadRepository<ProductImageFile>, IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(TheCheckpointDbContext context) : base(context)
        {
        }
    }
}
