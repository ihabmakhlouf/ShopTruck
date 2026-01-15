namespace ShopTruck.Store.Domain.Entities;

public class Vendor
    {
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string AddressMail { get; set; } = null!;
    }

