using System.Collections.Generic;

namespace MessageService.Services.Interfaces
{
    public interface INotificationService
    {
        bool TryNotifyRecepients(List<string> recipients, string body);
    }
}
