using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using Sport.Core.Domain;

namespace Sport.Infrastructure.Repositories
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=SportDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SportDB;Trusted_Connection=True;");
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>()
                .HasMany<Event>(u => u.MyEvents)
                .WithOne(e => e.Creator)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserEvent>().HasKey(ue => new {ue.EventId, ue.UserId});

            modelBuilder.Entity<Event>().HasMany(e => e.EnrolledUsers).WithOne(ue => ue.Event)
                .HasForeignKey(ue => ue.EventId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserEvent>().HasOne(ue => ue.User).WithMany(u => u.EnrolledTo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().OwnsOne(u => u.Address);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
    }
}
