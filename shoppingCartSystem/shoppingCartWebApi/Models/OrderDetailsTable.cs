using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace shoppingCartWebApi.Models
{
    public partial class OrderDetailsTable
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ProfileId { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

        public virtual OrderTable Order { get; set; }
        public virtual User Profile { get; set; }
    }
}
