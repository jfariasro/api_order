using appProduct.Models;
using appProduct.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IGenericRepository<OrderDetail> _repository;
        public OrderDetailController(IGenericRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateOrderDetail([FromBody] OrderDetail detail)
        {
            var message = await _repository.Create(detail);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        [HttpGet]
        [Route("Read")]
        public async Task<IActionResult> ReadOrderDetail()
        {
            var list = await _repository.Read();
            return Ok(list);
        }

        [HttpGet]
        [Route("Search/{id:int}")]
        public async Task<IActionResult> SearchOrderDetail([FromRoute] int id)
        {
            var order = await _repository.Search(id);
            return Ok(order);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateOrderDetail([FromRoute] int id, [FromBody] OrderDetail detail)
        {
            if (detail.IdOrderDetail != id)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Order Detail Not Found");
            }

            var state = await _repository.Update(id, detail);

            if (state)
            {
                return StatusCode(StatusCodes.Status200OK, "Order Detail Edited Successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Order Detail Not Found");
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteOrderDetail([FromRoute] int id)
        {
            var state = await _repository.Delete(id);
            if (state)
            {
                return StatusCode(StatusCodes.Status200OK, "Order Detail Deleted Successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Order Detail Not Found");
            }
        }
    }
}
