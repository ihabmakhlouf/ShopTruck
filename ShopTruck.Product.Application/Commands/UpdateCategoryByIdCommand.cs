using MediatR;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Entities;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Commands;

public record UpdateCategoryByIdCommand(CategoryDto CategoryDto, Guid Guid) : IRequest<bool>;

public class UpdateCategoryByIdQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<UpdateCategoryByIdCommand, bool>
    {
    public async Task<bool> Handle(UpdateCategoryByIdCommand request, CancellationToken cancellationToken)
        {
        Category category = new Category
            {
            Name = request.CategoryDto.Name,
            };
        return await categoryRepository.UpdateCategoryAsync(category, request.Guid);
        }
    }

