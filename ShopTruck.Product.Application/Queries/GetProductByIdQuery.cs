using MediatR;
using ShopTruck.Infrastructure.Cache.Abstractions;
using ShopTruck.Infrastructure.Cache.Keys;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Queries;

public record GetProductByIdQuery(Guid Guid) : IRequest<ProductDto>;
public class GetProductByIdQueryHandler(IProductRepository productRepository, ICacheService cache) : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
    private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(30);
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = CacheKeys.Product(request.Guid);

                var productDto = await cache.GetOrSetAsync(cacheKey, async () =>
                {
                    var product = await productRepository.GetProductByIdAsync(request.Guid);
                    return new ProductDto
                        {
                        Id = product.Id,
                        Description = product.Description,
                        Price = product.Price,
                        Name = product.Name,
                        CategoryId = product.CategoryId,
                        };
                }, CacheTtl);

            return productDto ?? new ProductDto();
        }
    }

