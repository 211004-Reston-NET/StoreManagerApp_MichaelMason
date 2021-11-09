using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class SOrder
    {
        public SOrder()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrderId { get; set; }
        public int? StoreNumber { get; set; }
        public int? CustNumber { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Customer CustNumberNavigation { get; set; }
        public virtual Storefront StoreNumberNavigation { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }

        public override string ToString()
        {
            var output = $@"Order #{this.OrderId} | Total: {this.TotalPrice}
{this.LineItems}
--

            
            ";
            return output;
        }
    }
}
