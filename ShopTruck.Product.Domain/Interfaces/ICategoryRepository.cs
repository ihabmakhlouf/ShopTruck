using ShopTruck.Product.Domain.Entities;

namespace ShopTruck.Product.Domain.Interfaces;

public interface ICategoryRepository
    {
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> GetCategoryByIdAsync(Guid id);
    Task<bool> UpdateCategoryAsync(Category category, Guid id);
    Task<bool> DeleteCategoryByIdAsync(Guid id);
    }

