using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotatnikMechanika.IdentityServer.Data;

namespace NotatnikMechanika.IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            //string connectionString = _config.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(config =>
            {
                //config.UseSqlServer(connectionString);
                config.UseInMemoryDatabase("Memory");
            });

            // AddIdentity registers the services
            services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            string assembly = typeof(Startup).Assembly.GetName().Name;

            //var filePath = Path.Combine(_env.ContentRootPath, "is_cert.pfx");
            //var certificate = new X509Certificate2(filePath, "password");

            services.AddIdentityServer()
                .AddAspNetIdentity<IdentityUser>()
                //.AddConfigurationStore(options =>
                //{
                //    options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                //        sql => sql.MigrationsAssembly(assembly));
                //})
                //.AddOperationalStore(options =>
                //{
                //    options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                //        sql => sql.MigrationsAssembly(assembly));
                //})
                //.AddSigningCredential(certificate);
                .AddInMemoryApiResources(Configuration.GetApis())
                .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                .AddInMemoryClients(Configuration.GetClients())
                .AddDeveloperSigningCredential();

            services.AddAuthentication();
                //.AddFacebook(config => {          // TO IMPLEMENT
                //    config.AppId = "3396617443742614";
                //    config.AppSecret = "secret";
                //});

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseIdentityServer();

            if (env.IsDevelopment())
            {
                app.UseCookiePolicy(new CookiePolicyOptions()
                {
                    MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax
                });
            }

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
