using System;
using MessageService.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageService.DataBase
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options) { }

        public DbSet<DbMessage> Messages { get; set; }

        public DbSet<DbRecipient> Recipients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbMessage>().HasKey(c => c.Id);
            modelBuilder.Entity<DbRecipient>().HasKey(c => c.Id);
        }

    }
}
