using System.Diagnostics;
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

        //  Genereras av ChatGpt. Denna kod uppdaterar en befintlig produkt i databasen. Den har en Async i sig vilket innebär att den körs utan att blocka huvudtråden. Den returnerar en "true" eller "false" med hjälp av (task<bool>). True betyder att uppdateringen lyckades medan false betyder tvärtom och att den inte lyckades.
    
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
            existingProduct.ProductDescription = form.ProductDescription;
            existingProduct.Price = form.ProductPrice;
            //existingProduct.Id = form.Id;

            await _productRepository.UpdateAsync(existingProduct);
        }
        return true;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var customerEntity = await _productRepository.GetAsync(x => x.Id == id);
        if (customerEntity == null)
            return false;

        try
        {
            var result = await _productRepository.DeleteAsync(customerEntity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }




}
