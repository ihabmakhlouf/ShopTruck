using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopTruck.Store.Application.Commands;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Application.Queries;

namespace ShopTruck.Store.Api.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(ISender sender) : ControllerBase
        {

        [HttpPost("CreateStore")]
        public async Task<IActionResult> CreateStoreAsync([FromBody] StoreDto storeDto)
            {
            var newStore = await sender.Send(new CreateStoreCommand(storeDto));
            return Ok(newStore);
            }

        [HttpPost("UpdateStore")]
        public async Task<IActionResult> UpdateStoreByIdAsync([FromBody] Guid guid)
            {
            var store = await sender.Send(new UpdateStoreByIdCommand(guid));
            return Ok(store);
            }

        [HttpPost("DeleteStoreById")]
        public async Task<IActionResult> DeleteStoreByIdAsync([FromBody] Guid guid)
            {
            var store = await sender.Send(new DeleteStoreByIdCommand(guid));
            return Ok(store);
            }

        [HttpPost("GetStoreById{guid}")]
        public async Task<IActionResult> GetStoreByIdAsync(Guid guid)
            {
            var store = await sender.Send(new GetStoreByIdQuery(guid));
            return Ok(store);
            }

        [HttpPost("GetStores")]
        public async Task<IActionResult> GetStoresAsync()
            {
            var stores = await sender.Send(new GetAllStoresQuery());
            return Ok(stores);
            }
        }

    }
