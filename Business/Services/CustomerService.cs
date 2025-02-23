using System.Diagnostics;
using Business.DTOs;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Data.Services;



public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    public async Task<Customer?> CreateCustomerAsync(CustomerRegistrationForm form)
    {

        var entity = await _customerRepository.GetAsync(x => x.FirstName == form.FirstName);
        var customerEntity = CustomerFactory.Create(form);
        await _customerRepository.CreateAsync(customerEntity!);

        return CustomerFactory.Create(customerEntity!);
    }


    public async Task<IEnumerable<Customer?>> GetAllCustomersAsync()
    {
        var customerEntities = await _customerRepository.GetAllAsync();
        return customerEntities.Select(CustomerFactory.Create);

    }



    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);
        return customerEntity != null ? CustomerFactory.Create(customerEntity) : null;
    }


    // Denna kod genereras av ChatGpt. Den uppdaterar en befintlig Kund (Customer) i databasen, med hjälp av (Task<bool>) så returneras en "true" eller "false", om uppdateringen lyckades så kommer det att bli "true" om inte, så kommer det bli "false".
    public async Task<bool> UpdateCustomerAsync(int id, CustomerUpdateForm form)
    {
        if (form == null)
        {
            return false;
        }
        var existingCustomer = await _customerRepository.GetAsync(x => x.Id == id);
        if (existingCustomer != null)
        {
            existingCustomer.FirstName = form.FirstName;
            //existingCustomer.Id = form.Id;

            await _customerRepository.UpdateAsync(existingCustomer);
        }
        return true;
    }




   

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);
        if (customerEntity == null)
            return false;

        try
        {
            var result = await _customerRepository.DeleteAsync(customerEntity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }



}
