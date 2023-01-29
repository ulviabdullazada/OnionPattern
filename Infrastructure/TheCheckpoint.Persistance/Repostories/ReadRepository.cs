using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Linq.Expressions;
using TheCheckpoint.Application.Repostories;
using TheCheckpoint.Domain.Entities.Common;
using TheCheckpoint.Persistance.Contexts;

namespace TheCheckpoint.Persistance.Repostories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly TheCheckpointDbContext _context;

        public ReadRepository(TheCheckpointDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll(bool isTracking = true)
        {
            return _checkTrack(Table.AsQueryable(), isTracking);
        }

        public async Task<T> GetById(string id, bool isTracking = true)
        {
            return await _checkTrack(Table.AsQueryable(), isTracking).FirstOrDefaultAsync(x=>x.Id == Guid.Parse(id));
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            return await _checkTrack(Table.AsQueryable(), isTracking).FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            return _checkTrack(Table.Where(expression).AsQueryable(), isTracking);
        }
        IQueryable<T> _checkTrack(IQueryable<T> query, bool isTracking)
        {
            if (!isTracking)
            {
                return query.AsNoTracking();
            }
            return query;
        }
    }
}
