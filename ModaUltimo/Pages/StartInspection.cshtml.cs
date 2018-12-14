using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModaUltimo.Models;
using ModaUltimo.Pages;


namespace ModaUltimo.Pages
{
    public class StartInspectionModel : PageModel
    {
        private readonly AppDbContext _context;


public StartInspectionModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StartInspectionForm StartInspectionForm { get; set; }

        public void OnGet()
        {
           PopulateSelectLists();
        }


public IActionResult OnPost()
        {
            if (!ModelState.IsValid) 
            {
                PopulateSelectLists();
                return Page();
            }
            return Page();
        }


 private void PopulateSelectLists() {
            // GET ACTIVE stores
            var inventory = _context.Inventory
                                 .OrderBy(x =>x.InventoryName)
                                 .ToList();

            
        ViewData["InventoryId"] = new SelectList(inventory, "Id", "InventoryName");

            var stores = _context.Store
                                 .OrderBy(x => x.City)
                                 .ToList();
            ViewData["StoreId"] = new SelectList(stores, "Id", "City");
 }

    }
}