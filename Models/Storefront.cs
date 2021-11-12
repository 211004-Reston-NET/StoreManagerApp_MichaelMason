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
        string _storeName;
        string _storeAddress;

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

        public override string ToString()
        {
            var output = $@"Store {this.StoreNumber}
Name: {this.StoreName}
Address: {this.StoreAddress}            
";
        return output;
        }

        public string ListView()
        {
            return $"[{this.StoreNumber}] {this.StoreName} | {this.StoreAddress}";
        }
    }
}
