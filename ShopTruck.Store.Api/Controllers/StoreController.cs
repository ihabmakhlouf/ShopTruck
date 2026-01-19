using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopTruck.Store.Application.Commands;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Application.Queries;
using ShopTruck.Store.Domain.Entities;

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

        [HttpPost("UpdateStore{guid}")]
        public async Task<IActionResult> UpdateStoreByIdAsync([FromBody] StoreDto storeDto, Guid guid)
            {
            var store = await sender.Send(new UpdateStoreByIdCommand(guid, storeDto));
            return Ok(store);
            }

        [HttpPost("DeleteStoreById")]
        public async Task<IActionResult> DeleteStoreByIdAsync([FromBody] Guid guid)
            {
            var store = await sender.Send(new DeleteStoreByIdCommand(guid));
            return Ok(store);
            }

        [HttpGet("GetStoreById{guid}")]
        public async Task<IActionResult> GetStoreByIdAsync(Guid guid)
            {
            var store = await sender.Send(new GetStoreByIdQuery(guid));
            return Ok(store);
            }

        [HttpGet("GetStores")]
        public async Task<IActionResult> GetStoresAsync()
            {
            var stores = await sender.Send(new GetAllStoresQuery());
            return Ok(stores);
            }

        [HttpGet("GetStoresByVendorId{vendorId}")]
        public async Task<IActionResult> GetStoresByVendorIdAsync(Guid vendorId)
            {
            var stores = await sender.Send(new GetStoresByVendorIdQuery(vendorId));
            return Ok(stores);
            }

        [HttpPost("GetStoresByIds")]
        public async Task<IActionResult> GetStoresByIdsAsync([FromBody] List<Guid> ids)
            {
            var stores = await sender.Send(new GetStoresByIdsQuery(ids));
            return Ok(stores);
            }
        }

    }
