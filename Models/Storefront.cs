using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

#nullable disable

namespace Models
{
    public partial class Storefront
    {
        public Storefront()
        {
            Inventories = new HashSet<Inventory>();
            SOrders = new HashSet<SOrder>();
        }

        public int StoreNumber { get; set; }

        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z0-9.' !]+$", ErrorMessage = "Invalid name")]
        public string StoreName { get; set; }

        [Required]
        [Display(Name = "Address")]
        [RegularExpression(@"^[a-zA-Z0-9. ,'-]+$", ErrorMessage = "Invalid address")]
        public string StoreAddress { get; set; }
       
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<SOrder> SOrders { get; set; }
    }
}
