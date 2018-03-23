using System.Threading.Tasks;
using MessageService.Storage.Models;

namespace MessageService.Storage.Interfaces
{
    public interface IStorageService
    {
        Task Add(DbMessage dbMessage);
    }
}
