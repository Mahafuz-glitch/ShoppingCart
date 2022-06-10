using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace shoppingCartWebApi.Models
{
    public partial class AddressTable
    {
        public int AddressTableId { get; set; }
        public int ProfileId { get; set; }
        public int? StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }

        public virtual User Profile { get; set; }
    }
}
