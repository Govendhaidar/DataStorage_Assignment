﻿using System.Diagnostics;
using Business.DTOs;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using Data.Repositories;

namespace Data.Services;


public class StatusTypeService(IStatusRepository statusRepository) : IStatusTypeService
{
    private readonly IStatusRepository _statusTypeRepository = statusRepository;

   

    public async Task<StatusType?> CreateStatusTypeAsync(StatusTypeRegistrationForm form)
    {
        var statusType = await _statusTypeRepository.GetAsync(x => x.StatusName == form.StatusName);
        var statusTypeEntity = StatusTypeFactory.Create(form);
        await _statusTypeRepository.CreateAsync(statusTypeEntity!);

        return null!;

    }
    


    public async Task<IEnumerable<StatusType?>> GetAllStatusTypesAsync()
    {
        var statusEntities = await _statusTypeRepository.GetAllAsync();
        return statusEntities.Select(StatusTypeFactory.Create);
    }

    public async Task<StatusType?> GetStatusTypeByIdAsync(int id)
    {
        var statusEntity = await _statusTypeRepository.GetAsync(x => x.Id == id);
        return statusEntity != null ? new StatusType { Id = statusEntity.Id, StatusName = statusEntity.StatusName } : null;
    }

    public async Task<bool> UpdateStatusTypeAsync(int id, StatusTypeUpdateForm form)
    {
        var existingStatus = await _statusTypeRepository.GetAsync(x => x.Id == id);
        if (existingStatus == null)
        {
            return false;
        }

        existingStatus.StatusName = form.StatusName;
        await _statusTypeRepository.UpdateAsync(existingStatus);

        return true;
    }


    public async Task<bool> DeleteStatusTypeAsync(int id)
    {
        var customerEntity = await _statusTypeRepository.GetAsync(x => x.Id == id);
        if (customerEntity == null)
            return false;

        try
        {
            var result = await _statusTypeRepository.DeleteAsync(customerEntity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }


}
