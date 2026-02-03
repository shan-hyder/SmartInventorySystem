using Microsoft.EntityFrameworkCore;
using SmartInventorySystem.Data;
using SmartInventorySystem.DTOs;
using SmartInventorySystem.Entities;
using SmartInventorySystem.Interfaces;
using SmartInventorySystem.Enums;
using SmartInventorySystem.Exceptions;

namespace SmartInventorySystem.Services
{
    public class StockTransactionService:IStockTransactionService
    {
        private readonly AppDbContext _DbContext;
        public StockTransactionService(AppDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public async Task<StockResponseDTO> CreateStockTransaction(StockTransactionCreateDTO dto)
        {
            var product = await _DbContext.Products.FirstOrDefaultAsync(p => p.Id == dto.ProductId && p.IsActive == true);
            if ( product == null )
            {
                throw new BusinessException("Product Not Found");
            }
            var stock = await _DbContext.Stocks.FirstOrDefaultAsync(p => p.ProductId == dto.ProductId);
            if(stock==null)
            {
                stock = new Stock
                {
                    ProductId = dto.ProductId,
                    Quantity = 0
                };
                await _DbContext.Stocks.AddAsync(stock);
            }
            if (dto.TransactionType == StockTransactionType.IN)
            {
                stock.Quantity += dto.TransactionQuantity;
                stock.LastUpdate = DateTime.UtcNow;
               
            }
            else
            {
                if((stock.Quantity-dto.TransactionQuantity)<0)
                {
                    throw new BusinessException("Insufficient Stock For The Action");
                }
                stock.Quantity -= dto.TransactionQuantity;
                stock.LastUpdate = DateTime.UtcNow;
            }
                

            var transaction = new StockTransaction
            {
                ProductId = dto.ProductId,
                TransactionQty = dto.TransactionQuantity,
                TransactionReason = dto.TransactionReason,
                TransactionType = dto.TransactionType,
                TransactionTime = DateTime.UtcNow
            };
            await _DbContext.StockTransactions.AddAsync(transaction);
            await _DbContext.SaveChangesAsync();
            return new StockResponseDTO
            {
                ProductId = dto.ProductId,
                ProductName=product.Name,
                Quantity = stock.Quantity,
                CategoryName = await _DbContext.Products.Where(p => p.Id == dto.ProductId).Select(p => p.Category.Name).FirstOrDefaultAsync(),
                LastUpdated = stock.LastUpdate

            };
        }
    }
}
