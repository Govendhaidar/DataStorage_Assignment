using Business.DTOs;
using Business.Models;

namespace Business.Interfaces;

public interface IProductService
{
    Task<Product?> CreateProductAsync(ProductRegistrationForm form);
    Task<Product?> GetProductByIdAsync(int id);
    Task<IEnumerable<Product?>> GetAllProductAsync();
    Task<bool> UpdateProductAsync(int id, ProductUpdateForm form);
    Task<bool> DeleteProductAsync(int id);

}
