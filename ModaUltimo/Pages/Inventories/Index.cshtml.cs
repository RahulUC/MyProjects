using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModaUltimo.Models;

namespace ModaUltimo.Pages.Inventories
{
    public class IndexModel : PageModel
    {
        private readonly ModaUltimo.Models.AppDbContext _context;

        public IndexModel(ModaUltimo.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Inventory> Inventory { get;set; }

        public async Task OnGetAsync()
        {
            Inventory = await _context.Inventory
                .Include(i => i.Product)
                .Include(i => i.Store).ToListAsync();
        }
    }
}
