using MediatR;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Commands;

public record DeleteProductByIdCommand(Guid Guid) : IRequest<bool>;

public class DeleteProductByIdCommandHandler(IProductRepository productRepository) : IRequestHandler<DeleteProductByIdCommand, bool>
    {
    public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
        return await productRepository.DeleteProductByIdAsync(request.Guid);
        }
    }
