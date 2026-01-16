using MediatR;
using ShopTruck.Infrastructure.Cache.Abstractions;
using ShopTruck.Infrastructure.Cache.Keys;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Queries;

public record GetAllStoresQuery : IRequest<IEnumerable<StoreDto>>;

public class GetAllStoresQueryHandler(IStoreRepository storeRepository, ICacheService cache) : IRequestHandler<GetAllStoresQuery, IEnumerable<StoreDto>>
    {
    private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(30);
    public async Task<IEnumerable<StoreDto>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {

        var cacheKey = CacheKeys.StoreList();
        var stores = await cache.GetOrSetAsync(cacheKey, async () =>
        {
            var allStores = await storeRepository.GetStoresAsync();

            // Mapper Product -> ProductDto
            return allStores.Select(p => new StoreDto
                {
                Id = p.Id,
                Name = p.Name,
                AddressDto = new AddressDto
                    {
                    City = p.Address.City,
                    PostalCode = p.Address.PostalCode,
                    Street = p.Address.Street,
                    },
                VendorId = p.VendorId
                }).ToList();

        }, CacheTtl);
        return stores ?? new List<StoreDto>();
        }
    }
