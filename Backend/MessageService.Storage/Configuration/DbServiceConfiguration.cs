using MessageService.Storage.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.Storage.Configuration
{
    public static class DbServiceConfiguration
    {
        public static void AddInMemoryMessageStorage(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryContext>(options => options.UseInMemoryDatabase("MessagesDB"));
            services.AddTransient<IStorageService, StorageServicecs>();
        }
    }
}
