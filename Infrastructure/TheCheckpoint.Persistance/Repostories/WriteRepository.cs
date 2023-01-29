using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TheCheckpoint.Application.Repostories;
using TheCheckpoint.Domain.Entities.Common;
using TheCheckpoint.Persistance.Contexts;

namespace TheCheckpoint.Persistance.Repostories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly TheCheckpointDbContext _context;

        public WriteRepository(TheCheckpointDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> CreateAllAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public async Task<bool> CreateAsync(T data)
        {
            EntityEntry<T> entity = await Table.AddAsync(data);
            return entity.State == EntityState.Added;
        }

        public bool Delete(T data)
        {
            EntityEntry<T> entity = Table.Remove(data);
            return entity.State == EntityState.Deleted;
        }

        public bool Delete(string id)
        {
            T data = Table.SingleOrDefault(t => t.Id == Guid.Parse(id));
            return Delete(data);
        }

        public bool DeleteAll(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public bool Update(T data)
        {
            EntityEntry<T> entity = Table.Update(data);
            return entity.State == EntityState.Modified;
        }

        public bool UpdateAll(List<T> datas)
        {
            Table.UpdateRange(datas);
            return true;
        }
    }
}
