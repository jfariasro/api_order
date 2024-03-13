using appProduct.Models;
using appProduct.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IGenericRepository<Customer> _repository;

        public CustomerController(IGenericRepository<Customer> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            var message = await _repository.Create(customer);
            return StatusCode(StatusCodes.Status200OK, message);
        }

        [HttpGet]
        [Route("Read")]
        public async Task<IActionResult> ReadCustomer()
        {
            var list = await _repository.Read();
            return Ok(list);
        }

        [HttpGet]
        [Route("Search/{id:int}")]
        public async Task<IActionResult> SearchCustomer([FromRoute] int id)
        {
            var customer = await _repository.Search(id);
            return Ok(customer);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            if(customer.idcustomer != id)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Customer Not Found");
            }

            var state = await _repository.Update(id, customer);

            if (state)
            {
                return StatusCode(StatusCodes.Status200OK, "Customer Edited Successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Customer Not Found");
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var state = await _repository.Delete(id);
            if (state)
            {
                return StatusCode(StatusCodes.Status200OK, "Customer Deleted Successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Customer Not Found");
            }
        }
    }
}
