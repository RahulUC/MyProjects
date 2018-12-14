
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModaUltimo.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [StringLength(60)]
        [Display(Name = "Category Description")]
        public string Desc { get; set; }
        
        // public int ProductID { get; set; }
        //public Product Product { get; set; }

        public ICollection<Product> Products { get; set; }
        // ADD PROPERTIES HERE
    }
}
            