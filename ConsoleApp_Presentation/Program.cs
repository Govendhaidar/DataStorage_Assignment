﻿using Business.Interfaces;
using Business.Services;
using ConsoleApp_Presentation.Dialogs;
using ConsoleApp_Presentation.InterFaces;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\DataStorage_Assignment\\Data\\Databases\\Local_Databases.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"))



    .AddScoped<ICustomerRepository, CustomerRepository>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IStatusRepository, StatusTypeRepository>()
    .AddScoped<IProjectRepository, ProjectRepository>()
    .AddScoped<IProductRepository, ProductRepository>()


    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IStatusTypeService, StatusTypeService>()
    .AddScoped<IProjectService, ProjectService>()
    .AddScoped<IProductService, ProductService>()


    .AddScoped<ICustomerDialog, CustomerDialogs>()
    .AddScoped<IUserDialog, UserDialog>()
    .AddScoped<IStatusTypeDialog, StatusTypeDialog>()
    .AddScoped<IProjectDialog, ProjectDialog>()
    .AddScoped<IProductDialog, ProductDialog>()

    .BuildServiceProvider();

await ShowMainMenu(services);
static async Task ShowMainMenu(ServiceProvider services)
{

    bool isRunning = true;

    do
    {
        Console.Clear();
        Console.WriteLine("### MAIN MENU ###");
        Console.WriteLine("1. CUSTOMER MENU");
        Console.WriteLine("2. USER MENU");
        Console.WriteLine("3. STATUS MENU");
        Console.WriteLine("4. PROJECT MENU");
        Console.WriteLine("5. PRODUCT MENU");
        Console.WriteLine("6. EXIT");
        Console.WriteLine("**");
        Console.Write("Select your option: ");

        string option = Console.ReadLine()!;

        switch (option.ToLower())
        {
            case "1":
                var customerDialog = services.GetRequiredService<ICustomerDialog>();
                await customerDialog.MenuOptions();
                break;

            case "2":
                var userDialog = services.GetRequiredService<IUserDialog>();
                await userDialog.MenuOptions();
                break;

            case "3":
                var statusDialog = services.GetRequiredService<IStatusTypeDialog>();
                await statusDialog.MenuOptions();
                break;

            case "4":
                var projectDialog = services.GetRequiredService<IProjectDialog>();
                await projectDialog.MenuOptions();
                break;

            case "5":
                var productDialog = services.GetRequiredService<IProductDialog>();
                await productDialog.MenuOptions();
                break;

            case "6":
                Console.WriteLine("Ending program..");
                return;

            default:
                Console.WriteLine("Invalid option, please try again.");
                Console.ReadLine();
                break;
        }

    } while (isRunning);
}
    