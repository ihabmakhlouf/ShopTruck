namespace ShopTruck.Store.Application.Dtos;

public class StoreDto
    {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public AddressDto AddressDto { get; set; } = null!;
    }

