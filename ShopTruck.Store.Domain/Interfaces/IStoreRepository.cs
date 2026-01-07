namespace ShopTruck.Store.Domain.Interfaces;

public interface IStoreRepository
    {
    Task<Entities.Store> AddStoreAsync(Entities.Store store);
    Task<Entities.Store> UpdateStoreByIdAsync(Guid guid);
    Task<bool> DeleteStoreByIdAsync(Guid guid);
    Task<Entities.Store> GetStoreByIdAsync(Guid guid);
    }

