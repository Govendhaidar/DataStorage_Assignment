﻿using Business.DTOs;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusTypeFactory

{
    public static StatusTypeRegistrationForm CreateRegistrationForm() => new();
    public static StatusTypeUpdateForm CreateUpdateForm() => new();
    public static StatusTypeEntity? Create(StatusTypeRegistrationForm form)  => form == null ? null : new()
    {
        StatusName = form.StatusName
    };

    public static StatusType? Create(StatusTypeEntity entity) =>  entity == null ? null : new()
    {
        Id = entity.Id,
        StatusName = entity.StatusName



    };

    public static StatusTypeUpdateForm Create(StatusType statusType) => new()
    {
        Id = statusType.Id,
        StatusName = statusType.StatusName

       
    };


    public static StatusTypeEntity Create(StatusTypeEntity StatusTypeEntity, StatusTypeUpdateForm form) => new()
    {
        Id = StatusTypeEntity.Id,
        StatusName = form.StatusName
    };
       
}
