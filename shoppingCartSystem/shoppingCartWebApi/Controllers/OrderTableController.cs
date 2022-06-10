using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoppingCartWebApi.Models;
using shoppingCartWebApi.Repository;

namespace shoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTableController : ControllerBase
    {
        private readonly IOrderTableREpository _orderTableREpository;
        public OrderTableController(IOrderTableREpository orderTableREpository)
        {
            _orderTableREpository = orderTableREpository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var orderTables = _orderTableREpository.GetAll();
            return Ok(orderTables);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                throw new InvalidException("Invalid Id");
            }
            var orderTable = _orderTableREpository.GetOrderTable(id);
            if (orderTable == null)
            {
                throw new InvalidException("Invalid Id");
            }
            return new OkObjectResult(orderTable);
        }
        [HttpPost]
        public IActionResult Post(OrderTable orderTable)
        {
            _orderTableREpository.Create(orderTable);
            return Ok(orderTable);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, OrderTable orderTable)
        {
            _orderTableREpository.UpdateOrderTable(orderTable);
            return Ok(orderTable);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderTableREpository.DeleteOrderTable(id);
            return Ok();
        }
    }
}
