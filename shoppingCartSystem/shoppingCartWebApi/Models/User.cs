using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace shoppingCartWebApi.Models
{
    public partial class User
    {
        public User()
        {
            AddressTable = new HashSet<AddressTable>();
            OrderDetailsTable = new HashSet<OrderDetailsTable>();
            OrderTable = new HashSet<OrderTable>();
            Payment = new HashSet<Payment>();
        }

        public int ProfileId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ProfileRole { get; set; }
        public string ProfilePassword { get; set; }
        public string MobileNumber { get; set; }

        public virtual ICollection<AddressTable> AddressTable { get; set; }
        public virtual ICollection<OrderDetailsTable> OrderDetailsTable { get; set; }
        public virtual ICollection<OrderTable> OrderTable { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
