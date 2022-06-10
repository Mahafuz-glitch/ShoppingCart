using shoppingCartWebApi.Models;
using System.Collections.Generic;

namespace shoppingCartWebApi.Repository
{
    public interface IAddressRepository
    {
        AddressTable Create(AddressTable addressTable);
        IEnumerable<AddressTable> GetAll();
        AddressTable GetAddressTables(int id);
        void DeleteAddressTable(int id);
        void UpdateAddressTable(AddressTable addressTable);
    }
}
