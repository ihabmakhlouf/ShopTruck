using MediatR;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Entities;
using ShopTruck.Product.Domain.Interfaces;

namespace MyApp.Application.Commands;

public record AddProductCommand(ProductDto productDto) : IRequest<ProductDto>;

public class AddProductCommandHandler(IProductRepository productRepository) : IRequestHandler<AddProductCommand, ProductDto>
    {
    public async Task<ProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
        var product = await productRepository.AddProductAsync(new Product
            {
            Name = request.productDto.Name,
            CategoryId = request.productDto.CategoryId,
            Description = request.productDto.Description,
            Price = request.productDto.Price,
            });

        return new ProductDto
            {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            CategoryId = product.CategoryId,
            Price = product.Price,
            };
        }
    }