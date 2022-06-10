using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shoppingCartWebApi.Models;
using shoppingCartWebApi.Repository;

namespace shoppingCartWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
           _addressRepository = addressRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var product = _addressRepository.GetAll();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                throw new InvalidException("Invalid Id");
            }
            var address = _addressRepository.GetAddressTables(id);
            if (address == null)
            {
                throw new InvalidException("Invalid Id");
            }
            return new OkObjectResult(address);
        }
        [HttpPost]
        public IActionResult Post(AddressTable addressTable)
        {
            _addressRepository.Create(addressTable);
            return Ok(addressTable);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, AddressTable addressTable)
        {
            _addressRepository.UpdateAddressTable(addressTable);
            return Ok(addressTable);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _addressRepository.DeleteAddressTable(id);
            return Ok();
        }
    }
}
