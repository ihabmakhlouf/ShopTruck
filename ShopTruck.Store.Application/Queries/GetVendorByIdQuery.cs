using MediatR;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Queries;

public record GetVendorByIdQuery(Guid Guid): IRequest<VendorDto>;

public class GetVendorByIdQueryHandler(IVendorRepository vendorRepository) : IRequestHandler<GetVendorByIdQuery, VendorDto>
    {
    public async Task<VendorDto> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
        {
        var vendor = await vendorRepository.GetByIdAsync(request.Guid, cancellationToken);
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

