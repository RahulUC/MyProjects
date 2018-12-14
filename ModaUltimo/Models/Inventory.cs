
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ModaUltimo.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Inventory Name")]
        public string InventoryName {get;set;}
        [Required]
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Manufacture_date { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
       
       //public ICollection<Product> Products { get; set; }
        public int StoreID { get; set; }
        public Store Store { get; set; }
       
        // ADD PROPERTIES HERE
    }
}           