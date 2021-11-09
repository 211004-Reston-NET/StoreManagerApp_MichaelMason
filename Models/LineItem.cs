using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class LineItem
    {
        public int LineId { get; set; }
        public int? OrderId { get; set; }
        public int? ProdId { get; set; }
        public int Quantity { get; set; }

        public virtual SOrder Order { get; set; }
        public virtual Product Prod { get; set; }
    }
}
