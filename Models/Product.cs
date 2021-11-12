using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

#nullable disable

namespace Models
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            LineItems = new HashSet<LineItem>();
        }

        public int ProdId { get; set; }
        string _prodName;
        decimal _prodPrice;
        string _prodDescription;
        string _prodCategory;

        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z0-9.' !-]+$", ErrorMessage = "Invalid name")]
        public string ProdName
        {
            get => _prodName;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("You must enter a product name");
                }
                if (!Regex.IsMatch(value, @"^[a-z0-9.' !-]+$", RegexOptions.IgnoreCase))
                {
                    throw new FormatException("Product name is invalid");
                }
                _prodName = value;
            }
        }

        [Required]
        [Display(Name = "Price")]
        public decimal ProdPrice 
        {
            get => _prodPrice;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("You must enter a price");
                }
                if (!Regex.IsMatch(value.ToString(), @"^[0-9.]+$", RegexOptions.IgnoreCase))
                {
                    throw new FormatException("Price is invalid");
                }
                _prodPrice = (decimal)value;
            }
        }


        [Required]
        [Display(Name = "Description")]
        [RegularExpression(@"^[a-zA-Z0-9.',/ !-]+$", ErrorMessage = "You must enter a description")]
        public string ProdDescription 
        {
            get => _prodDescription;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("You must enter an description");
                }
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9.',/ !-]+$", RegexOptions.IgnoreCase))
                {
                    throw new FormatException("Description is invalid");
                }
                _prodDescription = value;
            }
        }


        [Required]
        [Display(Name = "Category")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "You must enter a category")]
        public string ProdCategory
        {
            get => _prodCategory;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("You must enter an category");
                }
                if (!Regex.IsMatch(value, @"^[a-z ]+$", RegexOptions.IgnoreCase))
                {
                    throw new FormatException("Category is invalid");
                }
                _prodCategory = value;
            }
        }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
