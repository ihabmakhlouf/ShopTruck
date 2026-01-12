using MediatR;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Queries;

public record GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>;

public class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
    {
    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
         var categories = await categoryRepository.GetCategoriesAsync();
        return categories.Select(x => new CategoryDto
            {
             Id =x.Id,
             Name =x.Name,
            });
        }
    }
