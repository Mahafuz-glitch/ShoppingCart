using Microsoft.EntityFrameworkCore;
using shoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shoppingCartWebApi.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ShoppingCartContext _context;

        public AddressRepository(ShoppingCartContext context)
        {
            _context = context;
        }

        public AddressTable Create(AddressTable addressTable)
        {
            _context.AddressTable.Add(addressTable);
            _context.SaveChanges();
            return addressTable;
        }

        public void DeleteAddressTable(int id)
        {
            AddressTable addressTable = GetAddressTables(id);
            _context.Remove(addressTable);
            _context.SaveChanges();
        }

        public IEnumerable<AddressTable> GetAll()
        {
            return _context.AddressTable;       
        }

        public void UpdateAddressTable(AddressTable addressTable)
        {
            _context.Entry(addressTable).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public AddressTable GetAddressTables(int id)
        {
            return _context.AddressTable.FirstOrDefault(u => u.AddressTableId == id);
        }
    }
}
