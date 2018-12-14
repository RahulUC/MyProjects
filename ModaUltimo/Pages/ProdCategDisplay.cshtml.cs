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
    public class ProdCategDisplayModel : PageModel
    {
        private AppDbContext _context;

       public ProdCategDisplayModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> Categories { get; set; }
      
        public void OnGet()
        {
            Categories = _context.Category
                                        .Include(x => x.Products)
                                        .OrderBy(x => x.Name).ToList();
        }
    }
}