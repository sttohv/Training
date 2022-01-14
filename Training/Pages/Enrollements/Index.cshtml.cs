using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training.Data;
using Training.Infra;

namespace Training.Training.Pages.Enrollements
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<EnrollementData> EnrollementData { get;set; }

        public async Task OnGetAsync()
        {
            EnrollementData = await _context.Enrollements.ToListAsync();
        }
    }
}
