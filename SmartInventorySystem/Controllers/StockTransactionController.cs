using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartInventorySystem.DTOs;
using SmartInventorySystem.Interfaces;

namespace SmartInventorySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
 
    public class StockTransactionController : ControllerBase
    {
      private readonly IStockTransactionService _stockTransactionService;
        public StockTransactionController(IStockTransactionService stockTransactionService)
        {
            _stockTransactionService = stockTransactionService;
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateStockTransaction([FromBody] StockTransactionCreateDTO dto)
        {

            var result = await _stockTransactionService.CreateStockTransaction(dto);

            return Ok(result);

        }
    }
}