using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotatnikMechanika.Api.Data;
using System;
using System.Threading.Tasks;

namespace NotatnikMechanika.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            using IServiceScope scope = host.Services.CreateScope();
            IServiceProvider services = scope.ServiceProvider;

            try
            {
                var dbContext = services.GetRequiredService<AppDbContext>();
                if (dbContext.Database.IsSqlServer())
                {
                    dbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                logger.LogError(ex, "An error occurred while migrating or seeding the database.");

                throw;
            }

            await host.RunAsync();

        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }
    }
}
