using Microsoft.AspNetCore.Http;
using TheCheckpoint.Application.Abstracts.Storage;

namespace TheCheckpoint.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        IStorage _storage { get; }

        public string ServiceName => _storage.GetType().Name;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }
        public void Delete(string path)
            => _storage.Delete(path);

        public List<string> GetFiles(string path)
            => _storage.GetFiles(path);

        public bool HasFile(string path)
            => _storage.HasFile(path);

        public async Task<List<string>> UploadAsync(string path, ICollection<IFormFile> files)
            => await _storage.UploadAsync(path, files);
    }
}
