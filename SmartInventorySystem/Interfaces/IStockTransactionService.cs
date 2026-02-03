using SmartInventorySystem.DTOs;

namespace SmartInventorySystem.Interfaces
{
    public interface IStockTransactionService
    {
        Task<StockResponseDTO> CreateStockTransaction(StockTransactionCreateDTO dto);
    }
}
