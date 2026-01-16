using MediatR;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Entities;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Commands;

public record AddVendorCommand(VendorDto VendorDto) : IRequest<VendorDto>;


public class AddVendorCommandHandler(IVendorRepository vendorRepository) : IRequestHandler<AddVendorCommand, VendorDto>
    {
    public async Task<VendorDto> Handle(AddVendorCommand request, CancellationToken cancellationToken)
        {
        Vendor vendor = new Vendor
            {
            FirstName = request.VendorDto.FirstName,
            LastName = request.VendorDto.LastName,
            AddressMail = request.VendorDto.AddressMail,
            Password = request.VendorDto.Password,
            };
         vendor = await vendorRepository.AddVendorAsync(vendor, cancellationToken);
        return new VendorDto
            {
            Id = vendor.Id,
            FirstName = vendor.FirstName,
            LastName = vendor.LastName,
            AddressMail = vendor.AddressMail,
            Password = vendor.Password,
            };
        }
    }
