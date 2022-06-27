using Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Threading.Tasks;

namespace TU.Tracer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Creates a database inside our project
            using (var scope = host.Services.CreateScope()) {
                var servises = scope.ServiceProvider;
                try {
                    var context = servises.GetRequiredService<DataContext>();
                    var userManager = servises.GetRequiredService<UserManager<AppUser>>();
                    await context.Database.MigrateAsync();
                    await Seed.SeedDateAsync(context, userManager);
                }
                catch (Exception ex) {
                    var logger = servises.GetRequiredService<Logger<Program>>();
                    logger.LogError(ex, "Error during migration!!");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
