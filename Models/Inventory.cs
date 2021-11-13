using System.Linq;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    

    public partial class Inventory
    {
        public Inventory()
        {
        }

        public int InvId { get; set; }
        public int? StoreNumber { get; set; }
        public int? ProdId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Prod { get; set; }
        public virtual Storefront StoreNumberNavigation { get; set; }
    }
}
