using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using ShopTruck.Product.Application.Dtos;

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
        }
    }
