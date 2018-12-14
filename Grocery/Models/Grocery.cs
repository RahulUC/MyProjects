
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Grocery.Models
{
    public class Grocery
    {
        [Key]
        public int Id { get; set; }
   
        [Required(ErrorMessage = "Please provide Product name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2 - 100 characters only")]
      // Could not get this to function properly  [RegularExpression(@"^[A-Z]", ErrorMessage = "Product must be capitalized.")]
        public string Product { get; set; }

        [Required(ErrorMessage = "Please provide Product's Price")]
        [Range(0, 10000)]
        public Decimal Price { get; set; }


        public bool IsSold {get;set;}
        
        // ADD PROPERTIES HERE
    }
}
            