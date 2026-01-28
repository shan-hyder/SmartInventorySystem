using SmartInventorySystem.DTOs;

namespace SmartInventorySystem.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResponseDTO> CreateCategory(CategoryCreateDTO dto);
        Task<List<CategoryResponseDTO>> GetAllCategories();
        Task<bool> DeleteCategory(int id);
        Task<bool> UpdateCategory(int id,UpdateCategoryDTO dto);
        Task<CategoryResponseDTO> GetCategoryById(int id);
    }
}
