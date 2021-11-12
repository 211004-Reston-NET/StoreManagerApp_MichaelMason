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
        string _custEmail;
        string _custName;
        string _custAddress;
        string _custPhone;

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9.+@]+$", ErrorMessage = "Invalid email")]
        public string CustEmail
        {
            get => _custEmail;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("You must enter an email");
                }
                if (!Regex.IsMatch(value, @"^[a-z0-9.+@]+$", RegexOptions.IgnoreCase))
                {
                    throw new FormatException("Email address is invalid");
                }
                _custEmail = value;
            }
        }

        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid name")]
        public string CustName
        {
            get => _custName;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("You must enter an name");
                }
                if (!Regex.IsMatch(value, @"^[a-z -]+$", RegexOptions.IgnoreCase))
                {
                    throw new FormatException("Name is invalid");
                }
                _custName = value;
            }
        }

        [Required]
        [Display(Name = "Address")]
        [RegularExpression(@"^[a-zA-Z0-9. ,-]+$", ErrorMessage = "Invalid address")]
        public string CustAddress
        {
            get => _custAddress;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("You must enter an address");
                }
                if (!Regex.IsMatch(value, @"^[a-z0-9. ,-]+$", RegexOptions.IgnoreCase))
                {
                    throw new FormatException("Address is invalid");
                }
                _custAddress = value;
            }
        }

        [Required]
        [Display(Name = "Phone")]
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Invalid phone number")]
        public string CustPhone 
        {
            get => _custPhone;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("You must enter a phone number");
                }
                if (!Regex.IsMatch(value, @"^[0-9-]+$"))
                {
                    throw new FormatException("Phone is invalid");
                }
                _custPhone = value;
            }
        }

        public virtual ICollection<SOrder> SOrders { get; set; }
    
        public override string ToString()
        {
            var output = $@"Customer {this.CustNumber}
-----
Name: {this.CustName}
Address: {this.CustAddress}
Email: {this.CustEmail}
Phone: {this.CustPhone}
-----
";
            return output;

        }

        public string ToList()
        {
            return $"[{this.CustNumber}] | {this.CustName} | {this.CustAddress} | {this.CustEmail} | {this.CustPhone}";
        }
    }
}
