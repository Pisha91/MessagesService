using System;
using System.Collections.Generic;

namespace MessageService.DataBase.Models
{
    public class DbMessage
    {
        public DbMessage()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public ICollection<DbRecipient> Recipients { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsSent { get; set; }
    }
}
