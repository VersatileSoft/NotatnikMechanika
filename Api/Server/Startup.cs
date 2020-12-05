using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotatnikMechanika.Api.Data;
using NotatnikMechanika.Api.Data.Models;
using NotatnikMechanika.Api.Repository;
using NotatnikMechanika.Api.Service;

namespace NotatnikMechanika.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));

            services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")) // PublishConnection, DefaultConnection, DockerConnection             
             );

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, AppDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddSingleton(new MapperConfiguration(mc => mc.AddProfile(new MappingProfile())).CreateMapper());
            services.AddControllersWithViews();
            services.AddSwaggerGen();
            services.AddRazorPages();
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<RepositoryModule>();
            containerBuilder.RegisterModule<ServiceModule>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
