using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SmartInventorySystem.Data;
using SmartInventorySystem.DTOs;
using SmartInventorySystem.Entities;
using SmartInventorySystem.Interfaces;

namespace SmartInventorySystem.Services
{
    public class ProductService:IProductService
    {

        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProductResponseDTO>Create(ProductCreateDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                StockQuantity = dto.StockQuantity,
                CategoryId = dto.CategoryId,
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name

            };
            
        }
    public async Task<List<ProductResponseDTO>>GetAll()
        {

            var products=await _context.Products.Include(p=>p.Category).Select(p=>new ProductResponseDTO
            {
                Id=p.Id,
                Name=p.Name,
                Description=p.Description,
                Price=p.Price,
                StockQuantity=p.StockQuantity,
                CategoryId=p.CategoryId,
                CategoryName=p.Category.Name
            }).ToListAsync();
            return products;

        }
        public  async Task<ProductResponseDTO>GetById(int id)
        {
            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id==id);

            if(product==null)
            {
                return null;
            }
            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryName = product.Category.Name
            };
        }
        public async Task<bool>DeleteById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
            if(product==null)
            {
                return false;
            }
            product.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<ProductResponseDTO>Update(ProductUpdateDTO dto,int id)
        {
            var product = await _context.Products.Include(p=>p.Category).FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
            if (product==null)
            {
                return null;
            }
            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;
            product.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return new ProductResponseDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name
            };
        }
    }
}
