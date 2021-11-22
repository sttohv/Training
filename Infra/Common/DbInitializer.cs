
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Training.Data;
using Training.Data.Common;
using Training.Domain;
//using Training.Training.Data;

namespace Training.Infra.Common
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAsync(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager)
        {

            await roleManager.CreateAsync(new IdentityRole(UserRolesEnum.Visitor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRolesEnum.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRolesEnum.Client.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRolesEnum.Employee.ToString()));
        }
        
        public static void Initialize(ApplicationDbContext context)
        {
            context.SaveChanges();
        }

        public static async Task SeedSuperAdminAsync(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new UserData
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                FirstMidName = "Stina",
                LastName = "Maria",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await roleManager.CreateAsync(new IdentityRole(UserRolesEnum.SuperAdmin.ToString()));
                    await userManager.AddToRoleAsync(defaultUser, UserRolesEnum.Visitor.ToString());
                    await userManager.AddToRoleAsync(defaultUser, UserRolesEnum.Client.ToString());
                    await userManager.AddToRoleAsync(defaultUser, UserRolesEnum.Employee.ToString());
                    await userManager.AddToRoleAsync(defaultUser, UserRolesEnum.SuperAdmin.ToString());

                }

            }
        }
    }
}
