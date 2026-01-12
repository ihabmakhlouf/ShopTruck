using MediatR;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Queries;

public record GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>;

public class GetAllProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
        var products = await productRepository.GetProductsAsync();
        return products.Select(x => new ProductDto
            {
            Id = x.Id,
            Name = x.Name,
            CategoryId = x.CategoryId,
            Description = x.Description,
            });
        }
    }

