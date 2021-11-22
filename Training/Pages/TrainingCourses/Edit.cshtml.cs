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

namespace Training.Pages.TrainingCourses
{
    public class EditModel : PageModel
    {
        private readonly Infra.ApplicationDbContext _context;

        public EditModel(Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TrainingCourseData TrainingCourseData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainingCourseData = await _context.TrainingCourses.FirstOrDefaultAsync(m => m.Id == id);

            if (TrainingCourseData == null)
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

            _context.Attach(TrainingCourseData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingCourseDataExists(TrainingCourseData.Id))
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

        private bool TrainingCourseDataExists(string id)
        {
            return _context.TrainingCourses.Any(e => e.Id == id);
        }
    }
}
