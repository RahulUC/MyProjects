using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModaUltimo.Models;

namespace ModaUltimo.Pages
{
    public class InventoryPrdListModel : PageModel
    {
        private AppDbContext _context;
        public InventoryPrdListModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Inventories = _context.Inventory
                                    .Include(x => x.Product)
                                    .OrderBy(x => x.InventoryName).ToList();
        }
        public List<Inventory> Inventories { get; set; }
    }
}