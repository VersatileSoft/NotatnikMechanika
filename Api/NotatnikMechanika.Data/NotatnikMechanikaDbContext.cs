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

        public NotatnikMechanikaDbContext(DbContextOptions<NotatnikMechanikaDbContext> options) : base(options) { }

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
        }
    }
}
