using Microsoft.EntityFrameworkCore;
using ShopTruck.Store.Domain.Entities;
using ShopTruck.Store.Domain.Interfaces;
using ShopTruck.Store.Infrastructure.Data;

namespace ShopTruck.Store.Infrastructure.Repositories;

public class VendorRepository(AppDbContext dbContext) : IVendorRepository
    {
    public async Task<Vendor> AddVendorAsync(Vendor vendor, CancellationToken cancellationToken)
        {
        vendor.Id = Guid.NewGuid();
        await dbContext.AddAsync(vendor);
        await dbContext.SaveChangesAsync();
        return vendor;
        }

    public async Task<Vendor?> GetByEmailAsync(string email, CancellationToken cancellationToken)
        => await dbContext.Vendors.FirstOrDefaultAsync(v => v.AddressMail == email, cancellationToken);

    public async Task<Vendor?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
         => await dbContext.Vendors.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
    }

