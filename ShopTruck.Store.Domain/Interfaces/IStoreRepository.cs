namespace ShopTruck.Store.Domain.Interfaces;

public interface IStoreRepository
    {
    Task<Entities.Store> AddStoreAsync(Entities.Store store);
    Task<Domain.Entities.Store> UpdateStoreByIdAsync(Guid guid, Entities.Store store);
    Task<bool> DeleteStoreByIdAsync(Guid guid);
    Task<Entities.Store> GetStoreByIdAsync(Guid guid);
    Task<List<Domain.Entities.Store>> GetStoresAsync();
    }

