using MediatR;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Queries;

public record GetVendorByEmailQuery(string email) : IRequest<VendorDto>;

public class GetVendorByEmailQueryHandler(IVendorRepository vendorRepository) : IRequestHandler<GetVendorByEmailQuery, VendorDto>
    {
    public async Task<VendorDto> Handle(GetVendorByEmailQuery request, CancellationToken cancellationToken)
        {
        var vendor = await vendorRepository.GetByEmailAsync(request.email, cancellationToken);
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


