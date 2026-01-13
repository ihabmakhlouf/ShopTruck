using MediatR;
using ShopTruck.Product.Application.Dtos;
using ShopTruck.Product.Domain.Entities;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Application.Commands;

public record AddCategoryCommand(string categoryName) : IRequest<CategoryDto>;

public class AddCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<AddCategoryCommand, CategoryDto>
    {
    public async Task<CategoryDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
         var category = await categoryRepository.AddCategoryAsync(new Category { Name = request.categoryName });
         return new CategoryDto
             { 
             Id = category.Id,
             Name = category.Name,     
             };
        }
    }


