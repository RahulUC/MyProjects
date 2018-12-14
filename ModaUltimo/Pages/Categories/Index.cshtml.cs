using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModaUltimo.Models;

namespace ModaUltimo.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ModaUltimo.Models.AppDbContext _context;

        public IndexModel(ModaUltimo.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
