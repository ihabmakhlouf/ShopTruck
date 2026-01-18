namespace ShopTruck.Infrastructure.Cache.Keys;

public static class CacheKeys
    {
    public static string Product(Guid id) => $"product:{id}";
    public static string Store(Guid id) => $"store:{id}";
    public static string Category(Guid id) => $"category:{id}";
    public static string Vendor(string email) => $"vendor:{email}";
    public static string ProductList() => "product:list";
    public static string CategoryList() => "category:list";
    public static string StoreList() => "store:list";
    }

