using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Training.Data.Common;
using Training.Domain.Common;
using Training.Infra;
using Training.Infra.Common;

namespace Training.Training
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            GetRepo.SetProvider(host.Services);
            host.Run();
        }

        public static async void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<UserData>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await DbInitializer.SeedRolesAsync(userManager, roleManager);
                }
                catch(Exception ex)
                {
                    var logger = services.GetService<ILogger<Program>>();
                    logger?.LogError(ex, "An error occured while creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
