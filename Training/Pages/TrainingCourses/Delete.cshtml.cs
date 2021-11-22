using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training.Data;
using Training.Infra;

namespace Training.Training.Pages.TrainingCourses
{
    public class DeleteModel : PageModel
    {
        private readonly Infra.ApplicationDbContext _context;

        public DeleteModel(Infra.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrainingCourseData = await _context.TrainingCourses.FindAsync(id);

            if (TrainingCourseData != null)
            {
                _context.TrainingCourses.Remove(TrainingCourseData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
