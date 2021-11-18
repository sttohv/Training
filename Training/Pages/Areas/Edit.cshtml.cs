using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Training.Data;
using Training.Infra;

namespace Training.Training.Pages.Areas
{
    public class EditModel : PageModel
    {
        private readonly Infra.ApplicationDbContext _context;

        public EditModel(Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AreaData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaDataExists(AreaData.Id))
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

        private bool AreaDataExists(string id)
        {
            return _context.Areas.Any(e => e.Id == id);
        }
    }
}
