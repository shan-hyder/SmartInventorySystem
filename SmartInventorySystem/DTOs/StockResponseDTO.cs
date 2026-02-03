namespace SmartInventorySystem.DTOs
{
    public class StockResponseDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
