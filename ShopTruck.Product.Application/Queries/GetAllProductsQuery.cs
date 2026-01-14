using MediatR;
using ShopTruck.Infrastructure.Cache.Abstractions;
using ShopTruck.Infrastructure.Cache.Keys;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Queries;

public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;

public class GetAllProductsQueryHandler(IProductRepository productRepository, ICacheService cache) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
    private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(30);
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
        var cacheKey = CacheKeys.ProductList();

        var products = await cache.GetOrSetAsync(cacheKey, async () =>
        {
            var allProducts = await productRepository.GetProductsAsync();

            // Mapper Product -> ProductDto
            return allProducts.Select(p => new ProductDto
                {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CategoryId = p.CategoryId,
                Price = p.Price
                }).ToList();

        }, CacheTtl);
        return products ?? new List<ProductDto>();
        }
    }

