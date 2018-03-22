using System.Collections.Generic;

namespace MessageService.Notifications.Interfaces
{
    public interface INotificationService
    {
        bool TryNotifyRecepients(List<string> recipients, string body);
    }
}
