using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Training.Data;
using Training.Infra;

namespace Training.Training.Pages.Enrollements
{
    public class CreateModel : PageModel
    {
        private readonly Training.Infra.ApplicationDbContext _context;

        public CreateModel(Training.Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EnrollementData EnrollementData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollements.Add(EnrollementData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
