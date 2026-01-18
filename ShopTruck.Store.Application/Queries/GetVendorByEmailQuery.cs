using MediatR;
using ShopTruck.Infrastructure.Cache.Abstractions;
using ShopTruck.Infrastructure.Cache.Keys;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Queries;

public record GetVendorByEmailQuery(string email) : IRequest<VendorDto>;

public class GetVendorByEmailQueryHandler(IVendorRepository vendorRepository, ICacheService cache) : IRequestHandler<GetVendorByEmailQuery, VendorDto>
    {
    private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(30);
    public async Task<VendorDto> Handle(GetVendorByEmailQuery request, CancellationToken cancellationToken)
        {
        var cacheKey = CacheKeys.Vendor(request.email);

        var vendorDto = await cache.GetOrSetAsync(cacheKey, async () =>
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

        }, CacheTtl);
        return vendorDto;
        }
    }


