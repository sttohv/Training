using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Training.Data;
using Training.Domain.Common;
using Training.Infra;
using Training.Infra.Common;

namespace Training.Training
{
    public class Program
    {

        //var host = CreateHostBuilder(args).Build();


        public async static Task Main(string[] args)
        {
            
            //GetRepo.SetProvider(host.Services);
            //host.Run();
            var host = CreateHostBuilder(args).Build();
            CreateDbIfNotExists(host);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<UserData>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await DbInitializer.SeedRolesAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


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

    }
}
