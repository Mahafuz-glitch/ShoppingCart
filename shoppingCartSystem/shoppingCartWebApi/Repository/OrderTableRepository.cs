using Microsoft.EntityFrameworkCore;
using shoppingCartWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace shoppingCartWebApi.Repository
{
    public class OrderTableRepository : IOrderTableREpository
    {
        private readonly ShoppingCartContext _context;
        public OrderTableRepository(ShoppingCartContext context)
        {
            _context = context;
        }
        public OrderTable Create(OrderTable orderTable)
        {
            _context.OrderTable.Add(orderTable);
            _context.SaveChanges();
            return orderTable;
        }
        public void DeleteOrderTable(int id)
        {
            OrderTable orderTable = GetOrderTable(id);
            _context.Remove(orderTable);
            _context.SaveChanges();
        }
        public IEnumerable<OrderTable> GetAll()
        {
            return _context.OrderTable;
        }
        public void UpdateOrderTable(OrderTable orderTable)
        {
            _context.Entry(orderTable).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public OrderTable GetOrderTable(int id)
        {
            return _context.OrderTable.FirstOrDefault(u => u.OrderId == id);
        }
       

    }
}
