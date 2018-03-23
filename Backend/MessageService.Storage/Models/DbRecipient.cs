using System.Collections.Generic;

namespace MessageService.Storage.Models
{
    public class DbRecipient
    {
        public string Id { get; set; }

        public ICollection<DbMessageRecipient> MessageRecipients { get; set; }
    }
}
