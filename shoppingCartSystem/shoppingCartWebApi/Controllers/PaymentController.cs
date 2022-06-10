using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoppingCartWebApi.Models;
using shoppingCartWebApi.Repository;

namespace shoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var payment = _paymentRepository.GetAll();
            return Ok(payment);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                throw new InvalidException("Invalid Id");
            }
            var payment = _paymentRepository.GetPayment(id);
            if (payment == null)
            {
                throw new InvalidException("Invalid Id");
            }
            return new OkObjectResult(payment);
        }
        [HttpPost]
        public IActionResult Post(Payment payment)
        {
            _paymentRepository.Create(payment);
            return Ok(payment);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Payment payment)
        {
            _paymentRepository.UpdatePayment(payment);
            return Ok(payment);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _paymentRepository.DeletePayment(id);
            return Ok();
        }
    }
}
