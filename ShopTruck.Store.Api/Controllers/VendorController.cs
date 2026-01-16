using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopTruck.Store.Application.Commands;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Application.Queries;

namespace ShopTruck.Store.Api.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController(ISender sender) : ControllerBase
        {
        [HttpPost("CreateVendor")]
        public async Task<IActionResult> CreateVendorAsync([FromBody] VendorDto vendorDto)
            {
            var newVendor = await sender.Send(new AddVendorCommand(vendorDto));
            return Ok(newVendor);
            }

        [HttpGet("GetVendorById{guid}")]
        public async Task<IActionResult> GetVendorByIdAsync(Guid guid)
            {
            var vendor = await sender.Send(new GetVendorByIdQuery(guid));
            return Ok(vendor);
            }

        [HttpGet("GetVendorByEmail{email}")]
        public async Task<IActionResult> GetVendorByEmailAsync(string email)
            {
            var vendor = await sender.Send(new GetVendorByEmailQuery(email));
            return Ok(vendor);
            }
        }
    }
