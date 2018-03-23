using System.Threading.Tasks;
using MessageService.Notifications.DTO;

namespace MessageService.Notifications.Interfaces
{
    public interface INotificationProxy
    {
        Task Send(NotificationMessage message);
    }
}
