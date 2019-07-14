using Microsoft.EntityFrameworkCore;
using NotatnikMechanika.Data.Models;

namespace NotatnikMechanika.Data
{
    public class NotatnikMechanikaDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public NotatnikMechanikaDbContext(DbContextOptions<NotatnikMechanikaDbContext> options) : base(options) { }
    }
}
