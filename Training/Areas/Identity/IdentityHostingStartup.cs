using Microsoft.AspNetCore.Hosting;
using Training.Training.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace Training.Training.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}