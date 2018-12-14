using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModaUltimo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ModaUltimo.Pages
{
    public class Inventory_ManagementModel : PageModel
    {

        private AppDbContext _context;
        
        public Inventory_ManagementModel(AppDbContext context) {
            _context = context;
        }
        public ICollection<Category> Categories{get; set;}
        //public ICollection<Product> Products {get; set; }
        
       /*  public void OnGet()
        {
            Categories = _context.Category
                                    .Include(x => x.Products).ToList();
            //.OrderBy(x => x.Inventories.InventoryName)
        }*/

public IActionResult OnGet()
{
    ViewData["Id"] = new SelectList(_context.Category, "Id", "Name");
    return Page();
}


        public IActionResult OnPost()
{
    if (!ModelState.IsValid)
    {
        ViewData["Id"] = new SelectList(_context.Category, "Id", "Name");
        return Page();
    }
    return Page();
    // REST OF THE ON POST BEHAVIOR    
}
    }
}