using Microsoft.EntityFrameworkCore;
using shoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shoppingCartWebApi.Repository
{
    public class OrderDetailsTableRepository: IOrderDetailsTableRepository
    {
        private readonly ShoppingCartContext _context;
        public OrderDetailsTableRepository(ShoppingCartContext context)
        {
            _context = context;
        }
        public OrderDetailsTable Create(OrderDetailsTable orderDetailsTable)
        {
            _context.OrderDetailsTable.Add(orderDetailsTable);
            _context.SaveChanges();
            return orderDetailsTable;
        }
        public void DeleteOrderDetailsTable(int id)
        {
            OrderDetailsTable order = GetOrderDetailsTable(id);
            _context.Remove(order);
            _context.SaveChanges();
        }
        public IEnumerable<OrderDetailsTable> GetAll()
        {
            return _context.OrderDetailsTable;
        }
        public void UpdateOrderDetailsTable(OrderDetailsTable orderDetailsTable)
        {
            _context.Entry(orderDetailsTable).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public OrderDetailsTable GetOrderDetailsTable(int id)
        {
            return _context.OrderDetailsTable.FirstOrDefault(u => u.OrderDetailsId == id);
        }
    }
}
