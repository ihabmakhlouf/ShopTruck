namespace ShopTruck.Product.Domain.Entities;

public class Product
    {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Price { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
    }

