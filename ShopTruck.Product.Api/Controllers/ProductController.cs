using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using ShopTruck.Product.Application.Commands;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Application.Queries;

namespace ShopTruck.Product.Api.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender sender) : ControllerBase
        {

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductDto product)
            {
            var newProduct = await sender.Send(new AddProductCommand(product));
            return Ok(newProduct);
            }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProductByIdAsync([FromBody] ProductDto product, Guid guid)
            {
            var result = await sender.Send(new UpdateProductByIdCommand(guid, product));
            return Ok(result);
            }

        [HttpPost("DeleteProductById")]
        public async Task<IActionResult> DeleteProductByIdAsync([FromBody] Guid guid)
            {
            var result = await sender.Send(new DeleteProductByIdCommand(guid));
            return Ok(result);
            }

        [HttpGet("GetProductById{guid}")]
        public async Task<IActionResult> GetProductByIdAsync(Guid guid)
            {
            var product = await sender.Send(new GetProductByIdQuery(guid));
            return Ok(product);
            }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProductsAsync()
            {
            var products = await sender.Send(new GetAllProductsQuery());
            return Ok(products);
            }
        }
    }
    
