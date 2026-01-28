using SmartInventorySystem.Interfaces;
using SmartInventorySystem.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartInventorySystem.DTOs;
using SmartInventorySystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Exchange.WebServices.Data;

namespace SmartInventorySystem.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly AppDbContext _context;
        private object _logger;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<CategoryResponseDTO>CreateCategory(CategoryCreateDTO dto)
        {
            
                var category = new Category
                {
                    Name = dto.Name

                };
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return new CategoryResponseDTO
                {
                    Id = category.Id,
                    Name = category.Name
                };
        }
        public async Task<List<CategoryResponseDTO>>GetAllCategories()
        {
            return await _context.Categories.Where(
                c => c.IsActive).Select(c => new CategoryResponseDTO
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }
        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category==null||category.IsActive!=true)
            {
                return false;
            }
            category.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateCategory(int id,UpdateCategoryDTO dto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category==null||category.Name==dto.Name)
            {
                return false;
            }
            category.Name = dto.Name;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<CategoryResponseDTO>GetCategoryById(int id)
        {

            var category = await _context.Categories.FindAsync(id);
            if(category.IsActive!=true || category==null)
            {
                return null;
            }
            return new CategoryResponseDTO
            {
                Id = category.Id,
                Name = category.Name
            };


        }
    }
}
