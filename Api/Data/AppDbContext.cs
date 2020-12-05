using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NotatnikMechanika.Api.Data.Models;

namespace NotatnikMechanika.Api.Data
{
    public class AppDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Commodity> Commodities { get; set; }
        public virtual DbSet<OrderToCommodity> OrderToCommodities { get; set; }
        public virtual DbSet<OrderToService> OrderToServices { get; set; }

        public AppDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasMany(i => i.Orders)
                .WithOne(c => c.Car)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Commodities)
                .WithMany(c => c.Orders)
                .UsingEntity<OrderToCommodity>(
                    j => j.HasOne(o => o.Commodity).WithMany(c => c.OrderToCommodities),
                    j => j.HasOne(o => o.Order).WithMany(o => o.OrderToCommodities)
                    );
            
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Services)
                .WithMany(c => c.Orders)
                .UsingEntity<OrderToService>(
                    j => j.HasOne(o => o.Service).WithMany(c => c.OrderToServices),
                    j => j.HasOne(o => o.Order).WithMany(o => o.OrderToServices)
                );
        }
    }
}
