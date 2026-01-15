using ShopTruck.Store.Domain.Entities;

namespace ShopTruck.Store.Domain.Interfaces;

public interface IVendorRepository
    {
    Task<Vendor> AddVendorAsync(Vendor vendor);
    }

