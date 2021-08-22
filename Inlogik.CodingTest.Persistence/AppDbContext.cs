using System;
using Inlogik.CodingTest.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Inlogik.CodingTest.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Contact>()
                .Property(x => x.Name)
                .IsRequired();
        }
    }
}
