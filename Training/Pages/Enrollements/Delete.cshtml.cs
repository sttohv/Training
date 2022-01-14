using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training.Data;
using Training.Infra;

namespace Training.Training.Pages.Enrollements
{
    public class DeleteModel : PageModel
    {
        private readonly Training.Infra.ApplicationDbContext _context;

        public DeleteModel(Training.Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EnrollementData EnrollementData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EnrollementData = await _context.Enrollements.FirstOrDefaultAsync(m => m.Id == id);

            if (EnrollementData == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EnrollementData = await _context.Enrollements.FindAsync(id);

            if (EnrollementData != null)
            {
                _context.Enrollements.Remove(EnrollementData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
