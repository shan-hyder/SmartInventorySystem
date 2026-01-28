using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SmartInventorySystem.DTOs;
using SmartInventorySystem.Interfaces;

namespace SmartInventorySystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDTO dto)
        {
            return Ok(await _categoryService.CreateCategory(dto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllCategories());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if(category==null)
            {
                return NotFound("category not found");
            }
            return Ok(category);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (!result)
            {
                return BadRequest("Category deletion failed");
            }
            return Ok("Category soft deleted successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDTO dto)
        {
            var result = await _categoryService.UpdateCategory(id,dto);
            if(!result)
            {
                return BadRequest("Catgory Updation Failed");
            }
            return Ok("Category Updated Successfully");
        }

       
    }
}
