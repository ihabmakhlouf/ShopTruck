using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopTruck.Product.Application.Commands;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Application.Queries;

namespace ShopTruck.Product.Api.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ISender sender) : ControllerBase
        {

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategoryAsync([FromBody] string categoryName)
            {
            var newCategory = await sender.Send(new AddCategoryCommand(categoryName));
            return Ok(newCategory);
            }

        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryByIdAsync([FromBody] CategoryDto category, Guid guid)
            {
            var result = await sender.Send(new UpdateCategoryByIdCommand(category, guid));
            return Ok(result);
            }

        [HttpPost("DeleteCategoryById")]
        public async Task<IActionResult> DeleteCategoryByIdAsync([FromBody] Guid guid)
            {
            var result = await sender.Send(new DeleteCategoryByIdCommand(guid));
            return Ok(result);
            }

        [HttpGet("GetCategoryById{guid}")]
        public async Task<IActionResult> GetCategoryByIdAsync(Guid guid)
            {
            var category = await sender.Send(new GetCategoryByIdQuery(guid));
            return Ok(category);
            }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategoriesAsync()
            {
            var categories = await sender.Send(new GetAllCategoriesQuery());
            return Ok(categories);
            }
        }
    }

