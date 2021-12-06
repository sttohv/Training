using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training.Data;
using Training.Infra;

namespace Training.Training.Pages.Areas
{
    public class DetailsModel : PageModel
    {
        private readonly Infra.ApplicationDbContext _context;

        public DetailsModel(Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        public AreaData AreaData { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AreaData = await _context.Areas.FirstOrDefaultAsync(m => m.Id == id);

            if (AreaData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
