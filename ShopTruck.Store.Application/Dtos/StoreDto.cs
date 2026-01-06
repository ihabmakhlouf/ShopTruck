namespace ShopTruck.Store.Application.Dtos
    {
    public class StoreDto
        {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; private set; }
        }
    }
