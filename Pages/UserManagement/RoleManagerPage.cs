using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Training.Pages.UserManagement
{
    [Authorize(Roles = "SuperAdmin")]
    public class RoleManagerPage : PageModel
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManagerPage(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IList<IdentityRole> AllRoles { get; set; }

        [BindProperty]
        public IdentityRole Role { get; set; }

        public async Task OnGetAsync()
        {
            AllRoles = await _roleManager.Roles.ToListAsync();
        }

        public async Task<IActionResult> OnPostCreate(string roleName)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            return RedirectToPage("./roleManager");
        }
        public async virtual Task<IActionResult> OnPostEdit(string id, string roleNewName)
        {
            if (id == null)
            {
                return NotFound();
            }

            Role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                await _roleManager.SetRoleNameAsync(Role, roleNewName);
                await _roleManager.UpdateAsync(Role);
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToPage("./roleManager");
            }
            return RedirectToPage("./roleManager");
        }
        public async virtual Task<IActionResult> OnPostDelete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);

            if (Role != null)
            {
                await _roleManager.DeleteAsync(Role);
            }
            return RedirectToPage("./RoleManager");
        }
    }
}