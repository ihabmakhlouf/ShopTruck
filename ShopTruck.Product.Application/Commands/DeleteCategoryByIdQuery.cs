using MediatR;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Commands;

public record DeleteCategoryByIdQuery(Guid Guid) : IRequest<bool>;

public class DeleteCategoryByIdQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<DeleteCategoryByIdQuery, bool>
    {
    public async Task<bool> Handle(DeleteCategoryByIdQuery request, CancellationToken cancellationToken)
        {
        return await categoryRepository.DeleteCategoryByIdAsync(request.Guid);
        }
    }
