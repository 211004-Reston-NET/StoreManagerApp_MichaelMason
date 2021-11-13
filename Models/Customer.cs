using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

#nullable disable

namespace Models
{
    public partial class Customer
    {
        public Customer()
        {
            SOrders = new HashSet<SOrder>();
        }

        public int CustNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9.+@]+$", ErrorMessage = "Invalid email")]
        public string CustEmail { get; set; }

        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid name")]
        public string CustName { get; set; }

        [Required]
        [Display(Name = "Address")]
        [RegularExpression(@"^[a-zA-Z0-9. ,-]+$", ErrorMessage = "Invalid address")]
        public string CustAddress { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Invalid phone number")]
        public string CustPhone  { get; set; }

        public virtual ICollection<SOrder> SOrders { get; set; }
    }
}
