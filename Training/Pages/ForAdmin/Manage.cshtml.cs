using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Training.Data;
using Training.Facade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Training.Training.Pages.ForAdmin
{
    [Authorize(Roles = "SuperAdmin")]
    public class ManageModel : PageModel
    {
        private readonly UserManager<UserData> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public List<ManageUserRoleView> roleView { get; set; }
        public UserData Person;

        public ManageModel(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync(string userId)
        {
            Person = await _userManager.FindByIdAsync(userId);
            if (Person == null)
            {
                return NotFound();
            }
            roleView = new List<ManageUserRoleView>();
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = new ManageUserRoleView
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(Person, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                roleView.Add(userRolesViewModel);
            }
            return Page();
        }
        [BindProperty]
        public List<string> AreSelected { get; set; }
        public async Task<IActionResult> OnPostAsync(string userId)
        {
            Person = await _userManager.FindByIdAsync(userId);
            if (Person == null)
            {
                return Page();
            }
            var roles = await _userManager.GetRolesAsync(Person);
            var result = await _userManager.RemoveFromRolesAsync(Person, roles);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return Page();
            }
            result = await _userManager.AddToRolesAsync(Person, AreSelected);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return Page();
            }
            return RedirectToPage("./UserRolesModel");
        }
    }
}