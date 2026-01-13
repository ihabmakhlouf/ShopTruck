namespace ShopTruck.Product.Application.Dtos;

public class ProductDto
    {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public int Price { get; set; }
    }

