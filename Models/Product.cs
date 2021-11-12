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
        public string ProdName { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal ProdPrice { get; set; }

        [Required]
        [Display(Name = "Description")]
        [RegularExpression(@"^[a-zA-Z0-9.',/ !-]+$", ErrorMessage = "You must enter a description")]
        public string ProdDescription { get; set; }

        [Required]
        [Display(Name = "Category")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "You must enter a category")]
        public string ProdCategory { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
