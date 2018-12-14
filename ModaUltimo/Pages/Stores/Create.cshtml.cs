using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModaUltimo.Models;

namespace ModaUltimo.Pages.Stores
{
    public class CreateModel : PageModel
    {
        private readonly ModaUltimo.Models.AppDbContext _context;

        public CreateModel(ModaUltimo.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Store Store { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Store.Add(Store);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}