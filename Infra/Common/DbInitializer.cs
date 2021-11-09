
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Training.Data;
using Training.Data.Common;
//using Training.Training.Data;

namespace Training.Infra.Common
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAsync(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(UserRolesEnum.Client.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRolesEnum.Employee.ToString()));
             }

        public static void Initialize(ApplicationDbContext context)
        {
            context.SaveChanges();
        }
    }
}
