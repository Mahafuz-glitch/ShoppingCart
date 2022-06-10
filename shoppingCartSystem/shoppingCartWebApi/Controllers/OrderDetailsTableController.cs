using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoppingCartWebApi.Models;
using shoppingCartWebApi.Repository;

namespace shoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsTableController : ControllerBase
    {
        private readonly IOrderDetailsTableRepository _orderDetailsTableRepository;
        public OrderDetailsTableController(IOrderDetailsTableRepository orderDetailsTableRepository)
        {
            _orderDetailsTableRepository = orderDetailsTableRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var orderDetails = _orderDetailsTableRepository.GetAll();
            return Ok(orderDetails);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                throw new InvalidException("Invalid Id");
            }
            var orderDetails = _orderDetailsTableRepository.GetOrderDetailsTable(id);
            if (orderDetails == null)
            {
                throw new InvalidException("Invalid Id");
            }
            return new OkObjectResult(orderDetails);
        }
        [HttpPost]
        public IActionResult Post(OrderDetailsTable orderDetailsTable)
        {
            _orderDetailsTableRepository.Create(orderDetailsTable);
            return Ok(orderDetailsTable);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, OrderDetailsTable orderDetailsTable)
        {
            _orderDetailsTableRepository.UpdateOrderDetailsTable(orderDetailsTable);
            return Ok(orderDetailsTable);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderDetailsTableRepository.DeleteOrderDetailsTable(id);
            return Ok();
        }
    }
}
