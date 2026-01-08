using ShopTruck.Store.Domain.ValueObjects;

namespace ShopTruck.Store.Domain.Entities;

public class Store
    {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Address Address { get; set; } = null!;
    }

