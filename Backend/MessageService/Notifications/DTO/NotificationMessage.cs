using System;

namespace MessageService.Notifications.DTO
{
    [Serializable]
    public class NotificationMessage
    {
        public string RecipientId { get; set; }

        public string Body { get; set; }
    }
}
