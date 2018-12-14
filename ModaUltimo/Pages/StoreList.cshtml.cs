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
    public class StoreListModel : PageModel
    {
        private AppDbContext _context;
        public StoreListModel(AppDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Stores = _context.Store
                                    .Include(x=> x.Inventories)
                                    .ThenInclude(x => x.Product)
                                    .OrderBy(x => x.City).ToList();
        }
        public List<Store> Stores { get; set; }
    }
}