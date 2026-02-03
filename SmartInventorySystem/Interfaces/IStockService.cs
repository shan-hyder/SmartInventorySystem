using SmartInventorySystem.DTOs;

namespace SmartInventorySystem.Interfaces
{
    public interface IStockService
    {
        Task<List<StockResponseDTO>> GetAllStock();
        Task<StockResponseDTO> GetStockById(int id);
       
    }
}
