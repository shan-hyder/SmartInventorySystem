using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartInventorySystem.DTOs;
using SmartInventorySystem.Interfaces;
using SmartInventorySystem.Services;

namespace SmartInventorySystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService service)
        {
            _productService = service;
        }
        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO dto)
        {
            var createdProduct = await _productService.Create(dto);
            if (createdProduct == null)
            {
                return BadRequest("Product Creation Failed");
            }
            return Ok(createdProduct);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult>GetAllProducts()
        {
            var products = await _productService.GetAll();
            if(products==null||products.Count==0)
            {
                return NotFound("No products found");
            }
            return Ok(products);
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteById(id);
            if(!result)
            {
                return BadRequest("Product Deletion Failed");
            }
            return Ok(200);
        }
        [Authorize(Roles ="Admin,User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product=await _productService.GetById(id);
            if (product==null)
            {
                return NotFound(404);
            }
            return Ok(product);
        }
        [Authorize(Roles ="Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDTO dto)
        {
            var updatedProduct = await _productService.Update(dto, id);
            if(updatedProduct==null)
            {
                return BadRequest("Product Update Failed");
            }
            return Ok(updatedProduct);
        }
        
    
    }
}
