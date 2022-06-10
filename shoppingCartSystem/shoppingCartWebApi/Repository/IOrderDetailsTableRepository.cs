using shoppingCartWebApi.Models;
using System.Collections.Generic;

namespace shoppingCartWebApi.Repository
{
    public interface IOrderDetailsTableRepository
    {
        OrderDetailsTable Create(OrderDetailsTable orderDetailsTable);
        IEnumerable<OrderDetailsTable> GetAll();
        OrderDetailsTable GetOrderDetailsTable(int id);
        void DeleteOrderDetailsTable(int id);
        void UpdateOrderDetailsTable(OrderDetailsTable orderDetailsTable);
    }
}
