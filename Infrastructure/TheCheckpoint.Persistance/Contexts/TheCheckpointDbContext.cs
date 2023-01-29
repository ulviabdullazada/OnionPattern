using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCheckpoint.Domain.Entities;
using TheCheckpoint.Domain.Entities.Common;

namespace TheCheckpoint.Persistance.Contexts
{
    public class TheCheckpointDbContext:DbContext
    {
        public TheCheckpointDbContext(DbContextOptions options):base(options)
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var allAdded= ChangeTracker.Entries<BaseEntity>();
            foreach (var data in allAdded)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedTime = DateTime.UtcNow;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
