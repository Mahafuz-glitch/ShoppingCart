
using Microsoft.AspNetCore.Mvc;
using shoppingCartWebApi.Models;
using shoppingCartWebApi.Repository;

namespace shoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var product = _productRepository.GetAll();
                return Ok(product);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                throw new InvalidException("Invalid Id");
            }
            var product = _productRepository.GetProduct(id);
            if (product == null)
            {
                throw new InvalidException("Invalid Id");
            }
            return new OkObjectResult(product);
        }
        [HttpPost]
        public IActionResult Post(Product product )
        {
            try
            {
                _productRepository.Create(product);
                return Ok(product);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            try
            {
                _productRepository.UpdateProduct(product);
                return Ok(product);
            }
            catch (System.Exception)
            {

                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                return Ok();
            }
            catch (System.Exception)
            {

                return BadRequest();
            }
        }
    }
}
