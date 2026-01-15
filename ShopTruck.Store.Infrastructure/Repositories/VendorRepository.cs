using Microsoft.EntityFrameworkCore;
using ShopTruck.Store.Domain.Entities;
using ShopTruck.Store.Domain.Interfaces;
using ShopTruck.Store.Infrastructure.Data;

namespace ShopTruck.Store.Infrastructure.Repositories;

public class VendorRepository(AppDbContext dbContext) : IVendorRepository
    {
    public async Task<Vendor> AddVendorAsync(Vendor vendor)
        {
        vendor.Id = Guid.NewGuid();
        await dbContext.AddAsync(vendor);
        await dbContext.SaveChangesAsync();
        return vendor;
        }
    }

