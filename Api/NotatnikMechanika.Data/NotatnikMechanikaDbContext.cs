using Microsoft.EntityFrameworkCore;

namespace NotatnikMechanika.Data
{
    public class NotatnikMechanikaDbContext : DbContext
    {
        //  public virtual DbSet<User> Users { get; set; }


        public NotatnikMechanikaDbContext(DbContextOptions<NotatnikMechanikaDbContext> options) : base(options) { }
    }
}
