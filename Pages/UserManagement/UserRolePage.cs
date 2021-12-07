using System.Collections.Generic;
using System.Threading.Tasks;
using Training.Data;
using Training.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Training.Pages.UserManagement { 

    [Authorize(Roles = "SuperAdmin")]
    public class UserRolesModel : PageModel
    {
        private readonly UserManager<UserData> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public List<UserRoleView> userRolesViewModel;

        public UserRolesModel(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var allUsers = await _userManager.Users.ToListAsync();

            userRolesViewModel = new List<UserRoleView>();

            foreach (UserData user in allUsers)
            {
                var roleView = new UserRoleView();
                roleView.Id = user.Id;
                roleView.Email = user.Email;
                roleView.UserName = user.UserName; ;
                roleView.Roles = await GetUserRoles(user);
                userRolesViewModel.Add(roleView);
            }
            return Page();
        }

        private async Task<List<string>> GetUserRoles(UserData user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }
    }
}