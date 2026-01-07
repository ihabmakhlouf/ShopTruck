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
    }

