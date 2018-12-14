
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ModaUltimo.Models
{
    public class InvCheckForm
    {
        
        // ADD PROPERTIES HERE
        public int InventoryID { get; set; }

        [Display(Name="Quantity Check")]
        public int QuantityCheck { get; set; }
    }
}
            