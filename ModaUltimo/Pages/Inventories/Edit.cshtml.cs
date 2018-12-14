using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModaUltimo.Models;

namespace ModaUltimo.Pages.Inventories
{
    public class EditModel : PageModel
    {
        private readonly ModaUltimo.Models.AppDbContext _context;

        public EditModel(ModaUltimo.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inventory Inventory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inventory = await _context.Inventory
                .Include(i => i.Product)
                .Include(i => i.Store).FirstOrDefaultAsync(m => m.Id == id);

            if (Inventory == null)
            {
                return NotFound();
            }
           ViewData["ProductID"] = new SelectList(_context.Product, "Id", "Id");
           ViewData["StoreID"] = new SelectList(_context.Store, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(Inventory.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.Id == id);
        }
    }
}
