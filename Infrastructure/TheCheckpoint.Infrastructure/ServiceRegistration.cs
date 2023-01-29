using Microsoft.Extensions.DependencyInjection;
using TheCheckpoint.Application.Abstracts.Storage;
using TheCheckpoint.Application.Abstracts.Storage.Local;
using TheCheckpoint.Infrastructure.Enums;
using TheCheckpoint.Infrastructure.Services.Storage;

namespace TheCheckpoint.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
        }
        public static void AddStorage<T>(this IServiceCollection services) where T : class,IStorage
        {
            services.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection services, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    services.AddScoped<IStorage, ILocalStorage>();
                    break;
                case StorageType.Azure:
                    break;
                default:
                    services.AddScoped<IStorage, ILocalStorage>();
                    break;
            }
        }
    }
}
