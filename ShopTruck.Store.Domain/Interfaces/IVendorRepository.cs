using ShopTruck.Store.Domain.Entities;

namespace ShopTruck.Store.Domain.Interfaces;

public interface IVendorRepository
    {
    Task<Vendor> AddVendorAsync(Vendor vendor, CancellationToken cancellationToken);
    Task<Vendor?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Vendor?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }

