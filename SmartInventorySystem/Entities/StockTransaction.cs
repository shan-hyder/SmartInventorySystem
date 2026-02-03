using SmartInventorySystem.Enums;

namespace SmartInventorySystem.Entities
{
    public class StockTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int TransactionQty { get; set; }
        public StockTransactionType TransactionType { get; set; }
        public string TransactionReason { get; set; }
        public DateTime TransactionTime { get; set; } = DateTime.UtcNow;
    }
}
