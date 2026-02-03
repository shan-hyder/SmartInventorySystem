using SmartInventorySystem.Enums;

namespace SmartInventorySystem.DTOs
{
    public class StockTransactionResponseDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TransactionQuantity { get; set; }
        public StockTransactionType TransactionType { get; set; }
        public string TransactionReason { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}
