using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data.Models;

namespace NotatnikMechanika.Data
{
    public class NotatnikMechanikaDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Commodity> Commodities { get; set; }

        public NotatnikMechanikaDbContext(DbContextOptions<NotatnikMechanikaDbContext> options) : base(options) { }

        public DbSet<EntityType> GetDbSet<EntityType>() where EntityType : class
        {
            if (typeof(EntityType) == typeof(User))
            {
                return Users as DbSet<EntityType>;
            }

            if (typeof(EntityType) == typeof(Customer))
            {
                return Customers as DbSet<EntityType>;
            }

            if (typeof(EntityType) == typeof(Car))
            {
                return Cars as DbSet<EntityType>;
            }

            if (typeof(EntityType) == typeof(Order))
            {
                return Orders as DbSet<EntityType>;
            }

            if (typeof(EntityType) == typeof(Service))
            {
                return Services as DbSet<EntityType>;
            }

            if (typeof(EntityType) == typeof(Commodity))
            {
                return Commodities as DbSet<EntityType>;
            }

            return null;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Car>()
                .HasMany(i => i.Orders)
                .WithOne(c => c.Car)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
               .HasMany(i => i.Orders)
               .WithOne(c => c.Customer)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
               .HasMany(i => i.Orders)
               .WithOne(c => c.User)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
               .HasMany(i => i.Cars)
               .WithOne(c => c.User)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
              .HasMany(i => i.Customers)
              .WithOne(c => c.User)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
              .HasMany(i => i.Commodities)
              .WithOne(c => c.User)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
              .HasMany(i => i.Services)
              .WithOne(c => c.User)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderToCommodity>()
                .HasKey(bc => new { bc.CommodityId, bc.OrderId });
            modelBuilder.Entity<OrderToCommodity>()
                .HasOne(bc => bc.Order)
                .WithMany(b => b.OrderToCommodities)
                .HasForeignKey(bc => bc.OrderId);
            modelBuilder.Entity<OrderToCommodity>()
                .HasOne(bc => bc.Commodity)
                .WithMany(c => c.OrderToCommodities)
                .HasForeignKey(bc => bc.CommodityId);

            modelBuilder.Entity<OrderToService>()
              .HasKey(bc => new { bc.ServiceId, bc.OrderId });
            modelBuilder.Entity<OrderToService>()
                .HasOne(bc => bc.Order)
                .WithMany(b => b.OrderToServices)
                .HasForeignKey(bc => bc.OrderId);
            modelBuilder.Entity<OrderToService>()
                .HasOne(bc => bc.Service)
                .WithMany(c => c.OrderToServices)
                .HasForeignKey(bc => bc.ServiceId);
        }
    }
}
