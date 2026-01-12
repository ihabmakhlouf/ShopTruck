using MediatR;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Queries;

public record GetProductByIdQuery(Guid Guid) : IRequest<ProductDto>;
public class GetProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
        var product = await productRepository.GetProductByIdAsync(request.Guid);
        return new ProductDto
            {
            Id = product.Id,
            Description = product.Description,
            Name = product.Name,
            CategoryId = product.CategoryId,
            };
        }
    }

