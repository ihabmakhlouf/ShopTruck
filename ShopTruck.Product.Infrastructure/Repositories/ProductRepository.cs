using Microsoft.EntityFrameworkCore;
using ShopTruck.Product.Domain.Interfaces;

namespace ShopTruck.Product.Infrastructure.Repositories;

public class ProductRepository(AppDbContext dbContext) : IProductRepository
    {
    public async Task<Domain.Entities.Product> AddProductAsync(Domain.Entities.Product product)
        {
        product.Id = Guid.NewGuid();
        await dbContext.AddAsync(product);
        await dbContext.SaveChangesAsync();
        return product;
        }

    public async Task<bool> DeleteProductByIdAsync(Guid id)
        {
        var product = await GetProductByIdAsync(id);
        dbContext.Products.Remove(product);
        await dbContext.SaveChangesAsync();
        return true;
        }

    public async Task<Domain.Entities.Product> GetProductByIdAsync(Guid id)
        {
        var product = await dbContext.Products.FindAsync(id);
        if (product == null)
            throw new KeyNotFoundException($"Product with id {id} not found.");
        return product;
        }

    public async Task<IEnumerable<Domain.Entities.Product>> GetProductsAsync()
        {
        return await dbContext.Products.ToListAsync();
        }

    public async Task<bool> UpdateProductAsync(Domain.Entities.Product product, Guid id)
        {
        var productToUpdate = await GetProductByIdAsync(id);
        productToUpdate.Description = product.Description;
        productToUpdate.CategoryId = product.CategoryId;
        productToUpdate.Price = product.Price;
        productToUpdate.Name = product.Name;
        dbContext.Products.Update(productToUpdate);
        await dbContext.SaveChangesAsync();
        return true;
        }
    }

