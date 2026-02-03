namespace SmartInventorySystem.Entities
{
    public class Stock
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

    }
}
