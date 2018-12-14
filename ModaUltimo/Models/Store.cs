
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ModaUltimo.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Street Address")]
        public string Street {get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "City Name")]
        public string City {get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "State")]
        public string State {get; set; }
        [Required]
        [RegularExpression("[0-9]{5,6}", ErrorMessage = "Please enter valid Zip Code.")]
        [Display(Name = "Zip Code")]
        public int Zip {get; set; }
        // public bool? StoreOperation {get; set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime Open_date {get; set; }
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Store), "Close_Date_Validation")]
        public DateTime? Close_Date {get; set; }
        // ADD PROPERTIES HERE
        //public int InventoryID { get; set; }
        //public Inventory Inventory { get; set; }
       
        public ICollection<Inventory> Inventories { get; set; }

        public static ValidationResult Close_Date_Validation(DateTime? Close_Date, ValidationContext context) {
            if (Close_Date == null) {
                return ValidationResult.Success;
            }
            
            var instance = context.ObjectInstance as Store;
            if (instance == null) {
                return ValidationResult.Success;
            }
            
            if(Close_Date!= null && Close_Date > instance.Open_date)
            {
                return ValidationResult.Success;
                
            }
            return new ValidationResult("Close Date cannot be less than Open Date");            
            
        }

    }
}
            