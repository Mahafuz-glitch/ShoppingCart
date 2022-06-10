using shoppingCartWebApi.Models;
using System.Collections.Generic;

namespace shoppingCartWebApi.Repository
{
    public interface IOrderTableREpository
    {
        OrderTable Create(OrderTable orderTable);
        IEnumerable<OrderTable> GetAll();
        OrderTable GetOrderTable(int id);
        void DeleteOrderTable(int id);
        void UpdateOrderTable(OrderTable orderTable);
    }
}
