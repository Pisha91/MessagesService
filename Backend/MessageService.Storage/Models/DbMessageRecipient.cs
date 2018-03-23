namespace MessageService.Storage.Models
{
    public class DbMessageRecipient
    {
        public string MessageId { get; set; }

        public string RecipientId { get; set; }

        public  DbMessage Message { get; set; }

        public DbRecipient Recipient { get; set; }
    }
}
