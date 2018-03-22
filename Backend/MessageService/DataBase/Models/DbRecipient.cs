namespace MessageService.DataBase.Models
{
    public class DbRecipient
    {
        public string Id { get; set; }

        public string MessageId { get; set; }

        public DbMessage Message { get; set; }
    }
}
