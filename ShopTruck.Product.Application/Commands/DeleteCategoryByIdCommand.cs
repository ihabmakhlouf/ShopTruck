using MediatR;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Commands;

public record DeleteCategoryByIdCommand(Guid Guid) : IRequest<bool>;

public class DeleteCategoryByIdQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryByIdCommand, bool>
    {
    public async Task<bool> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
        {
        return await categoryRepository.DeleteCategoryByIdAsync(request.Guid);
        }
    }
