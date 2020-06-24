using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotatnikMechanika.Data;
using NotatnikMechanika.Data.Models;

namespace NotatnikMechanika.Server
{
    public static class StartupExtensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NotatnikMechanikaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")) // RemoteConnection, LocalConnection           
            );

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.SignIn.RequireConfirmedEmail = false;
            }).AddDefaultTokenProviders()
              .AddEntityFrameworkStores<NotatnikMechanikaDbContext>();
        }
    }
}
