
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ModaUltimo.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Product Size")]
        [CustomValidation(typeof(Product), "Product_Size_Validation")]
        public string Size { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        [CustomValidation(typeof(Product), "Product_Price_Validation")]
        public decimal Price { get; set; }
        
        public ICollection<Inventory> Inventories { get; set; }
        //public int InventoryID { get; set; }
        //public Inventory Inventory { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
        //
        // ADD PROPERTIES HERE
        public static ValidationResult Product_Price_Validation(decimal Price, ValidationContext context) 
        {
            var instance = context.ObjectInstance as Product;
            if (instance == null) {
                return ValidationResult.Success;
            }
            
            if(Price > 1)
            {
                return ValidationResult.Success;
                
            }
            return new ValidationResult("Price cannot be less than $1. Please enter correct price.");            
            
        }
        public static ValidationResult Product_Size_Validation(string Size, ValidationContext context)
         {
            if (Size == null) {
                return ValidationResult.Success;
            }
            
            var instance = context.ObjectInstance as Product;
            if (instance == null) {
                return ValidationResult.Success;
            }
            
            if(Size == "M" || Size == "S" || Size == "L")
            {
                return ValidationResult.Success;
                
            }
            return new ValidationResult("Please enter size in \"S\", \"M\", \"L\" only.");            
            
        }

        
    }
}
            