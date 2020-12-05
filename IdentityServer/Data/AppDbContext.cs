using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace NotatnikMechanika.IdentityServer.Data
{
    public class AppDbContext : ApiAuthorizationDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) 
            : base(options, operationalStoreOptions) { }
    }
}
