using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ModaUltimo.Models;
using ModaUltimo.Pages;

namespace ModaUltimo.Pages
{
    public class InvQuantCheckModel : PageModel
    {
private readonly AppDbContext _context;
        public InvQuantCheckModel(AppDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public InvCheckForm InvCheckForm { get; set; }
        
        public Inventory Inventory { get; set; }
        
        public IActionResult OnGet(int? id)
        {

            if (id == null) 
            {
                return StatusCode(406, "There was a problem fetching record due to invalid Id. Please try again.");
            }
            
            Inventory = _context.Inventory.Find(id);
            
            if (Inventory == null) {
                return  StatusCode(406, "There was a problem fetching record due to invalid Inventory.Please try again.");
            }
            
            InvCheckForm = new InvCheckForm();
            InvCheckForm.InventoryID = Inventory.Id;
            return Page();
        }
        

 public IActionResult OnPost() {
            Inventory = _context.Inventory.Find(InvCheckForm.InventoryID);
            
            if (!ModelState.IsValid) {
                 return  StatusCode(406, "The Model is invalid.Please try again.");
            }
            
            // UPDATE THE AGENT RETRIEVED FROM THE DATABASE
           Inventory.Quantity = InvCheckForm.QuantityCheck;
           // Inventor.OnLongTermLeave = false;
            // TELL THE DATABASE TO SAVE WHATEVER CHANGES WE MADE
            _context.SaveChanges();
           // return RedirectToPage("/InvQuantCheck", new  { id = Inventory.Id });
           return RedirectToPage("/InventoryPrdList");
        }
        
    }
}