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
    public class IndexModel : PageModel
    {
        private readonly Infra.ApplicationDbContext _context;

        public IndexModel(Infra.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AreaData> AreaData { get; set; }

        public async Task OnGetAsync()
        {
            AreaData = await _context.Areas.ToListAsync();
        }
    }
}

