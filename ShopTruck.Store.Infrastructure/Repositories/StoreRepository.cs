using ShopTruck.Store.Domain.Interfaces;
using ShopTruck.Store.Infrastructure.Data;

namespace ShopTruck.Store.Infrastructure.Repositories;

public class StoreRepository(AppDbContext dbContext) : IStoreRepository
    {
    public async Task<Domain.Entities.Store> AddStoreAsync(Domain.Entities.Store store)
        {
        store.Id = Guid.NewGuid();
        await dbContext.AddAsync(store);
        await dbContext.SaveChangesAsync();
        return store;
        }

    public Task<bool> DeleteStoreByIdAsync(Guid guid)
        {
        throw new NotImplementedException();
        }

    public Task<Domain.Entities.Store> UpdateStoreByIdAsync(Guid guid)
        {
        throw new NotImplementedException();
        }

    public async Task<Domain.Entities.Store> GetStoreByIdAsync(Guid guid)
        {
        var store = await dbContext.Stores.FindAsync(guid);
        return store;
        }
    }

