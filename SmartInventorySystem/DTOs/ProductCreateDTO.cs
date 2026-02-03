namespace SmartInventorySystem.DTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int? LowStockThreshold { get; set; }

    }
}
