namespace ShopTruck.Product.Domain.Interfaces;

public interface IProductRepository
    {
    Task<IEnumerable<Entities.Product>> GetProductsAsync();
    Task<Entities.Product> AddProductAsync(Entities.Product product);
    Task<Entities.Product> GetProductByIdAsync(Guid id);
    Task<bool> UpdateProductAsync(Entities.Product product, Guid id);
    Task<bool> DeleteProductByIdAsync(Guid id);
    }

