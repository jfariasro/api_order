using appProduct.Models;
using appProduct.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IGenericRepository<Order> _repository;
        public OrderController(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            var message = await _repository.Create(order);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpGet]
        [Route("Read")]
        public async Task<IActionResult> ReadOrder()
        {
            var list = await _repository.Read();
            return Ok(list);
        }

        [HttpGet]
        [Route("Search/{id:int}")]
        public async Task<IActionResult> SearchOrder([FromRoute] int id)
        {
            var order = await _repository.Search(id);
            return Ok(order);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] Order order)
        {
            if (order.IdOrder != id)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Order Not Found");
            }

            var state = await _repository.Update(id, order);

            if (state)
            {
                return StatusCode(StatusCodes.Status200OK, "Order Edited Successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Order Not Found");
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var state = await _repository.Delete(id);
            if (state)
            {
                return StatusCode(StatusCodes.Status200OK, "Order Deleted Successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Order Not Found");
            }
        }
    }
}
