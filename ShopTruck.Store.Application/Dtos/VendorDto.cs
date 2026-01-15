namespace ShopTruck.Store.Application.Dtos;

public class VendorDto
    {
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string AddressMail { get; set; } = null!;
    }

