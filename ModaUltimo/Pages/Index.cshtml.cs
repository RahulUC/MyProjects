using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModaUltimo.Models;

namespace ModaUltimo.Pages
{
    public class IndexModel : PageModel
    {
        private AppDbContext _context;
        public IndexModel(AppDbContext context) 
        {
            _context = context;
        }
        public void OnGet()
        {
 TotalStores = _context.Store
                            .Count();  

            TotalProducts = _context.Product
                            .Count(); 

            TotalCategories = _context.Category
                            .Count(); 
            
            TotalInventories = _context.Inventory
                            .Count(); 
        }
          public int TotalStores {get; set;}
        public int TotalProducts {get; set;}
        public int TotalCategories {get; set;}
        public int TotalInventories {get; set;}
    }
}
