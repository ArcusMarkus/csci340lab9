using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using csci340lab9.Data;
using csci340lab9.Models;

namespace csci340lab9.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly csci340lab9.Data.SchoolContext _context;

        public IndexModel(csci340lab9.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Department = await _context.Departments
                .Include(d => d.Administrator).ToListAsync();
        }
    }
}
