using MediatR;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Commands;

public record UpdateProductByIdCommand(Guid Guid, ProductDto ProductDto) : IRequest<bool>;

public class UpdateProductByIdCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductByIdCommand, bool>
    {
    public async Task<bool> Handle(UpdateProductByIdCommand request, CancellationToken cancellationToken)
        {
        Domain.Entities.Product product = new Domain.Entities.Product
            {
            Description = request.ProductDto.Description,
            Price = request.ProductDto.Price,
            CategoryId = request.ProductDto.CategoryId,
            Name = request.ProductDto.Name,
            };
         return await productRepository.UpdateProductAsync(product, request.Guid);
        }
    }
