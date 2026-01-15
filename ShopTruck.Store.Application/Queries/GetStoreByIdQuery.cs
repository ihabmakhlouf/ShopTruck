using MediatR;
using ShopTruck.Infrastructure.Cache.Abstractions;
using ShopTruck.Infrastructure.Cache.Keys;
using ShopTruck.Store.Application.Dtos;
using ShopTruck.Store.Domain.Interfaces;

namespace ShopTruck.Store.Application.Queries;

public record GetStoreByIdQuery(Guid Guid) : IRequest<StoreDto>;

public class GetStoreByIdQueryHandler(IStoreRepository storeRepository, ICacheService cache) : IRequestHandler<GetStoreByIdQuery, StoreDto>
    {
    private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(30);
    public async Task<StoreDto> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = CacheKeys.Store(request.Guid);

            var store = await cache.GetOrSetAsync(cacheKey, async () =>
                {
                    var store = await storeRepository.GetStoreByIdAsync(request.Guid);

                    // Mapper Product -> ProductDto
                    return new StoreDto
                        {
                        Id = store.Id,
                        Name = store.Name,
                        };

                }, CacheTtl);

            return store ?? new StoreDto();
        }
    }

