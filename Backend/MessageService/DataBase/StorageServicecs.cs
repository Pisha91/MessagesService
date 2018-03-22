using System.Threading.Tasks;
using MessageService.DataBase.Interfaces;
using MessageService.DataBase.Models;

namespace MessageService.DataBase
{
    public class StorageServicecs : IStorageService
    {
        private readonly InMemoryContext _inMemoryContext;

        public StorageServicecs(InMemoryContext inMemoryConte)
        {
            _inMemoryContext = inMemoryConte;
        }

        public async Task Add(DbMessage dbMessage)
        {
            await _inMemoryContext.Messages.AddAsync(dbMessage);
            await _inMemoryContext.SaveChangesAsync();
        }
    }
}
