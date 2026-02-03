using SmartInventorySystem.Enums;

namespace SmartInventorySystem.DTOs
{
    public class StockTransactionCreateDTO
    {
        public int ProductId { get; set; }
        public int TransactionQuantity { get; set; }
        public StockTransactionType TransactionType { get; set; }
        public string TransactionReason { get; set; }
    }
}
