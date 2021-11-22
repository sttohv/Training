using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training.Data;
using Training.Infra;

namespace Training.Training.Pages.TrainingCourses
{
    public class CreateModel : PageModel
    {
        private readonly Infra.ApplicationDbContext _context;

        public CreateModel(Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TrainingCourseData TrainingCourseData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TrainingCourses.Add(TrainingCourseData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
