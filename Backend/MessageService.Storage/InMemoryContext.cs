using MessageService.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Storage
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options) { }

        public DbSet<DbMessage> Messages { get; set; }

        public DbSet<DbRecipient> Recipients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbMessageRecipient>().HasKey(mr => new {mr.MessageId, mr.RecipientId});
            modelBuilder.Entity<DbMessageRecipient>()
                .HasOne(mr => mr.Message)
                .WithMany(m => m.MessageRecipients)
                .HasForeignKey(mr => mr.MessageId);

            modelBuilder.Entity<DbMessageRecipient>()
                .HasOne(mr => mr.Recipient)
                .WithMany(r => r.MessageRecipients)
                .HasForeignKey(mr => mr.RecipientId);

            modelBuilder.Entity<DbMessage>().HasKey(c => c.Id);

            modelBuilder.Entity<DbRecipient>().HasKey(c => c.Id);
        }

    }
}
