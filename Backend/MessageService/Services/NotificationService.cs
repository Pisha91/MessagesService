using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MessageService.Notifications.DTO;
using MessageService.Notifications.Interfaces;
using MessageService.Services.Interfaces;

namespace MessageService.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationProxy _notificationProxy;

        public NotificationService(INotificationProxy notificationProxy)
        {
            _notificationProxy = notificationProxy;
        }

        public bool TryNotifyRecepients(List<string> recipients, string body)
        {
            bool isAllRecipientsNotified = true;
            List<Task> notificationTasks = new List<Task>();
            foreach (var recipient in recipients)
            {
                var notificationMessage = new NotificationMessage
                {
                    Body = body,
                    RecipientId = recipient
                };

                notificationTasks.Add(_notificationProxy.Send(notificationMessage));
            }

            try
            {
                Task.WaitAll(notificationTasks.ToArray());
            }
            catch (AggregateException)
            {
                isAllRecipientsNotified = false;
            }
            

            return isAllRecipientsNotified;
        }
    }
}
