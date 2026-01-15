using MediatR;
using ShopTruck.Infrastructure.Cache.Abstractions;
using ShopTruck.Infrastructure.Cache.Keys;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Queries;

public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;

public class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, ICacheService cache) : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
    private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(100);
    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
        var cacheKey = CacheKeys.CategoryList();

        var categories = await cache.GetOrSetAsync(cacheKey, async () =>
        {
            var allCategories = await categoryRepository.GetCategoriesAsync();

            // Mapper Product -> ProductDto
            return allCategories.Select(p => new CategoryDto
                {
                Id = p.Id,
                Name = p.Name,
                }).ToList();

        }, CacheTtl);
        return categories ?? new List<CategoryDto>();
        }
    }
