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

    public async Task<bool> DeleteStoreByIdAsync(Guid guid)
        {
        var storeToDelete = await GetStoreByIdAsync(guid);
        dbContext.Remove(storeToDelete);
        await dbContext.SaveChangesAsync();
        return true;
        }

    public async Task<Domain.Entities.Store> UpdateStoreByIdAsync(Guid guid)
        {
        var storeToUpdate = await GetStoreByIdAsync(guid);
        dbContext.Stores.Update(storeToUpdate);
        await dbContext.SaveChangesAsync();
        return storeToUpdate;
        }

    public async Task<Domain.Entities.Store> GetStoreByIdAsync(Guid guid)
        {
        var store = await dbContext.Stores.FindAsync(guid);
        if (store == null)
            throw new KeyNotFoundException($"Store with id {guid} not found.");
        return store;
        }
    }

