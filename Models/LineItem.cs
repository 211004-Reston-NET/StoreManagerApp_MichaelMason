using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

#nullable disable

namespace Models
{
    public partial class LineItem
    {
        public int LineId { get; set; }
        public int? OrderId { get; set; }
        public int? ProdId { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid name")]
        public int Quantity { get; set; }

        public virtual SOrder Order { get; set; }
        public virtual Product Prod { get; set; }
    }
}
