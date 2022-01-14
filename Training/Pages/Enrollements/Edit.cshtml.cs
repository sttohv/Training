using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Training.Data;
using Training.Infra;

namespace Training.Training.Pages.Enrollements
{
    public class EditModel : PageModel
    {
        private readonly Training.Infra.ApplicationDbContext _context;

        public EditModel(Training.Infra.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EnrollementData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollementDataExists(EnrollementData.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EnrollementDataExists(string id)
        {
            return _context.Enrollements.Any(e => e.Id == id);
        }
    }
}
