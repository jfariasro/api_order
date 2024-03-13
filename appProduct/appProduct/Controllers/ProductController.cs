using appProduct.Models;
using appProduct.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductController(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var message = await _repository.Create(product);
            return StatusCode(StatusCodes.Status200OK, message);
        }

        [HttpGet]
        [Route("Read")]
        public async Task<IActionResult> ReadProduct()
        {
            var list = await _repository.Read();
            return Ok(list);
        }

        [HttpGet]
        [Route("Search/{id:int}")]
        public async Task<IActionResult> SearchProduct([FromRoute] int id)
        {
            var product = await _repository.Search(id);
            return Ok(product);
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product product)
        {
            if (product.idproduct != id)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Product Not Found");
            }
            var state = await _repository.Update(id, product);
            if (state)
            {
                return StatusCode(StatusCodes.Status200OK, "Product Edited Successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Product Not Found");
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var state = await _repository.Delete(id);
            if (state)
            {
                return StatusCode(StatusCodes.Status200OK, "Product Deleted Successfully");
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Product Not Found");
            }
        }

    }
}
