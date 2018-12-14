using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ModaUltimo.Models

{
    public class StartInspectionForm
    {
        [Display(Name="Store")]
        [Required(ErrorMessage = "Please select a store")]
        [CustomValidation(typeof(StartInspectionForm), "ValidateStore")]
        public int? StoreId { get; set; }
        
        
        [Display(Name="Inventory")]
        [Required(ErrorMessage = "Please select an inventory")]
        [CustomValidation(typeof(StartInspectionForm), "ValidateInventory")]
        public int? InventoryId { get; set; }


 public static ValidationResult ValidateStore(int? storeId, ValidationContext context) 
 {
            if (storeId == null) {
                return ValidationResult.Success;
            }
            var dbContext = context.GetService(typeof(AppDbContext)) as AppDbContext;
            var store = dbContext.Store
                                         .OrderBy(x =>x.City)
                                         .FirstOrDefault(x => x.Id == storeId.Value);

           
            if (store.Close_Date == null) {
                return new ValidationResult("Store is currently in running status");
            }

            return ValidationResult.Success;
        }


public static ValidationResult ValidateInventory(int? inventoryID, ValidationContext context) {
            if (inventoryID == null) {
                return ValidationResult.Success;
            }
            var dbContext = context.GetService(typeof(AppDbContext)) as AppDbContext;
            var inventory = dbContext.Inventory.FirstOrDefault(x => x.Id == inventoryID.Value);

            if (inventory == null) {
                return new ValidationResult("Please select a valid inventory");
            }

            if (inventory.Manufacture_date == null) {
                return new ValidationResult("This inventory does not have manufacture date");
            }
            
            return ValidationResult.Success;
        }
    }
}