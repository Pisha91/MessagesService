using System.Threading.Tasks;
using MessageService.DataBase.Models;

namespace MessageService.DataBase.Interfaces
{
    public interface IStorageService
    {
        Task Add(DbMessage dbMessage);
    }
}
