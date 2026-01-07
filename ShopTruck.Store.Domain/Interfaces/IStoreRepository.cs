namespace ShopTruck.Store.Domain.Interfaces
    {
    public interface IStoreRepository
        {
        Task<Entities.Store> AddStoreAsync(Entities.Store store);
        }
    }
