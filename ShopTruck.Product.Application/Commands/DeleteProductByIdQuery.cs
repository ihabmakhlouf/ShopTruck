using MediatR;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Commands;

public record DeleteProductByIdQuery(Guid Guid) : IRequest<bool>;

public class DeleteProductByIdQueryHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductByIdQuery, bool>
    {
    public async Task<bool> Handle(DeleteProductByIdQuery request, CancellationToken cancellationToken)
        {
        return await productRepository.DeleteProductByIdAsync(request.Guid);
        }
    }
