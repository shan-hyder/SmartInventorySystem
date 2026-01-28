using SmartInventorySystem.DTOs;

namespace SmartInventorySystem.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponseDTO> Create(ProductCreateDTO dto);
        Task<List<ProductResponseDTO>> GetAll();
        Task<bool> DeleteById(int id);
        Task<ProductResponseDTO> Update(ProductUpdateDTO dto,int id);
        Task<ProductResponseDTO> GetById(int id);
    }
}
