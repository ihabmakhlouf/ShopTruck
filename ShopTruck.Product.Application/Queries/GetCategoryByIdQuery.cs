using MediatR;
using ShopTruck.Infrastructure.Cache.Abstractions;
using ShopTruck.Infrastructure.Cache.Keys;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Queries;

public record GetCategoryByIdQuery(Guid Guid) : IRequest<CategoryDto>;

public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository,ICacheService cache) : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
    private static readonly TimeSpan CacheTtl = TimeSpan.FromMinutes(30);
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = CacheKeys.Category(request.Guid);
            var categoryDto = await cache.GetOrSetAsync(cacheKey, async () =>
                {
                    var category = await categoryRepository.GetCategoryByIdAsync(request.Guid);


                    return new CategoryDto
                        {
                        Id = category.Id,
                        Name = category.Name,
                        };

                }, CacheTtl);

            return categoryDto ?? new CategoryDto();
        }
    }