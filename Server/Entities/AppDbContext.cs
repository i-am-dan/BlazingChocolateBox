using Microsoft.EntityFrameworkCore;
using BlazingChocolate.Shared;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BlazingChocolate.Server
{
    public class AppDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default;
      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public static AppDbContext context { get; set; }

        // this is needed only when you need to create tables code-first
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one               many           one    many
            // Customers(BCBS) => Subscriptions(n) => ResourceGroups(n)
            modelBuilder.HasDefaultSchema("app");
            modelBuilder.Entity<Application>().ToTable("Application", "app");
            modelBuilder.Entity<Customer>().ToTable("Customer", "prddbo");
            modelBuilder.Entity<Application>().Property(s => s.Id).HasColumnName("ApplicationId");
            modelBuilder.Entity<Customer>().Property(s => s.Id).HasColumnName("OrganizationId");
        }
    }
}
