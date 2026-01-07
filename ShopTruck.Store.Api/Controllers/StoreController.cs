using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopTruck.Store.Application.Commands;
using ShopTruck.Store.Application.Dtos;

namespace ShopTruck.Store.Api.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(ISender sender) : ControllerBase
        {
        [HttpPost("AddStore")]
        public async Task<IActionResult> AddProductAsync([FromBody] StoreDto storeDto)
            {
            var newStore = await sender.Send(new CreateStoreCommand(storeDto));
            return Ok(newStore);
            }
        }
    }
