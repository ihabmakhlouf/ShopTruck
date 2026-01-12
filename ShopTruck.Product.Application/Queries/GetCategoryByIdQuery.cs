using MediatR;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Queries;

public record GetCategoryByIdQuery(Guid Guid) : IRequest<CategoryDto>;

public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
        var category = await categoryRepository.GetCategoryByIdAsync(request.Guid);
        return new CategoryDto
            {
            Id = category.Id,
            Name = category.Name,
            };
        }
    }