using Microsoft.EntityFrameworkCore;
using ShopTruck.Category.Domain.Entities;
using ShopTruck.Category.Domain.Interfaces;


namespace ShopTruck.Product.Infrastructure.Repositories;

internal class CategoryRepository(AppDbContext dbContext) : ICategoryRepository
    {
    public async Task<Category> AddCategoryAsync(Category category)
        {
        category.Id = Guid.NewGuid();
        await dbContext.AddAsync(category);
        await dbContext.SaveChangesAsync();
        return category;
        }

    public async Task<bool> DeleteCategoryByIdAsync(Guid id)
        {
        var category = await GetCategoryByIdAsync(id);
        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync();
        return true;
        }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
        return await dbContext.Categories.ToListAsync();
        }

    public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
        var category = await dbContext.Categories.FindAsync(id);
        if (category == null)
            throw new KeyNotFoundException($"Category with id {id} not found.");
        return category;
        }

    public async Task<bool> UpdateCategoryAsync(Category category, Guid id)
        {
        var categoryToUpdate = await GetCategoryByIdAsync(id);
        categoryToUpdate.Name = category.Name;
        dbContext.Categories.Update(categoryToUpdate);
        await dbContext.SaveChangesAsync();
        return true;
        }
    }

