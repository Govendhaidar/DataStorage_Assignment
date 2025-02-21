using Business.DTOs;
using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace Data.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;
    public async Task<Product?> CreateProductAsync(ProductRegistrationForm form)
    {
       
        var entity = await _productRepository.GetAsync(x  => x.ProductName == form.ProductName);
        var productEntity = ProductFactory.Create(form);
        await _productRepository.CreateAsync(productEntity!);

       return ProductFactory.Create(productEntity!);
    }


    public async Task<IEnumerable<Product?>> GetAllProductAsync()
    {
        var productEntities = await _productRepository.GetAllAsync();


        return productEntities.Select(ProductFactory.Create);
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var productEntity = await _productRepository.GetAsync(x => x.Id == id);
        return productEntity != null ? ProductFactory.Create(productEntity!) : null;

    }

        // ChatGpt
    
    public async Task<bool> UpdateProductAsync(int id, ProductUpdateForm form)
    {
        if (form == null)
        {
            return false;
        }
        var existingProduct = await _productRepository.GetAsync(x => x.Id == id);
        if (existingProduct != null)
        {
            existingProduct.ProductName = form.ProductName;
            existingProduct.Id = form.Id;

            await _productRepository.UpdateAsync(existingProduct);
        }
        return true;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var existingCustomer = await _productRepository.GetAsync(x => x.Id == id);
        if (existingCustomer != null)
        {
            return false;
        }

        return await _productRepository.DeleteAsync(x => x.Id == id);
    }


  

}
