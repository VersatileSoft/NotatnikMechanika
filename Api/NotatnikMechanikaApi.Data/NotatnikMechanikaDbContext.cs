using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotatnikMechanikaApi.Data
{
    public class NotatnikMechanikaDbContext : DbContext
    {
      //  public virtual DbSet<User> Users { get; set; }


        public NotatnikMechanikaDbContext(DbContextOptions<NotatnikMechanikaDbContext> options) : base(options) { }
    }
}
