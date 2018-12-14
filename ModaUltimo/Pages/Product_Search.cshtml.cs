using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModaUltimo.Models;
using Microsoft.EntityFrameworkCore;

namespace ModaUltimo.Pages
{
    public class Product_SearchModel : PageModel
    {
        private AppDbContext _context;

        public Product_SearchModel(AppDbContext context) {
                _context = context;
            }
        
        public void OnGet()
        {
            SearchCompleted = false;
        }
        // WE WILL STORE THE RESULTS IN THIS PROPERTY
        // THE 'BindProperty' Search will receive the value from the form
            // Note: The name attribute of the input in the HTML matches this name
            [BindProperty]
            public string Search { get; set; }
            public ICollection<Product> SearchResults { get; set; }
            public bool SearchCompleted { get; set; }
        public void OnPost() 
        {
            // PERFORM SEARCH
                if (string.IsNullOrWhiteSpace(Search)) {
                    // EXIT EARLY IF THERE IS NO SEARCH TERM PROVIDED
                    return;
        }
        SearchResults = _context.Product
                                        .Include(x => x.Category)
                                        .Include(x => x.Inventories)
                                        .Where(x => x.Name.ToLower().Contains(Search.ToLower()))
                                        .ToList();
                SearchCompleted = true;
    }
}
}