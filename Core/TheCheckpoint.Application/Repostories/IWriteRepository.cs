using TheCheckpoint.Domain.Entities.Common;

namespace TheCheckpoint.Application.Repostories
{
    public interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
    {
        Task<bool> CreateAsync(T data);
        Task<bool> CreateAllAsync(List<T> datas);
        bool Delete(T data);
        bool Delete(string id);
        bool DeleteAll(List<T> datas);
        bool Update(T data);
        bool UpdateAll(List<T> datas);
        Task<int> SaveAsync();
    }
}
