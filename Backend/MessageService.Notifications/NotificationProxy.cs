using System.Threading.Tasks;
using MessageService.Notifications.DTO;
using MessageService.Notifications.Interfaces;

namespace MessageService.Notifications
{
    public class NotificationProxy : INotificationProxy
    {
        public Task Send(NotificationMessage message)
        {
            // here should be implemented send message functionality (out of scope)
            return Task.Run(()=>throw new System.NotImplementedException());
        }
    }
}
