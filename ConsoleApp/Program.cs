using System;
using ConsoleApp;
using ConsoleApp.Contexts;
using ConsoleApp.Repositories;
using ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\source\datalagring\ConsoleApp\ConsoleApp\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<RoleRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<CustomerRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<RoleService>();
    services.AddScoped<ProductService>();
    services.AddScoped<CustomerService>();

    services.AddSingleton<ConsoleUI>();
}).Build();

var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();

while (true)
{
    Console.Clear();
    Console.WriteLine("[1] CREATE PRODUCT");
    Console.WriteLine("[2] GET PRODUCTS");
    Console.WriteLine("[3] UPDATE PRODUCT");
    Console.WriteLine("[4] DELETE PRODUCT");
    Console.WriteLine();
    Console.WriteLine("[5] CREATE CUSTOMER");
    Console.WriteLine("[6] GET CUSTOMERS");
    Console.WriteLine("[7] UPDATE CUSTOMER");
    Console.WriteLine("[8] DELETE CUSTOMER");
    Console.WriteLine();
    Console.WriteLine("[9] QUIT");

    var input = int.Parse(Console.ReadLine()!);

    switch (input)
    {
        case 1:
            consoleUI.CreateProduct_UI();
            break;
        case 2:
            consoleUI.GetProducts_UI();
            break;
        case 3:
            consoleUI.UpdateProduct_UI();
            break;
        case 4:
            consoleUI.DeleteProduct_UI();
            break;
        case 5:
            consoleUI.CreateCustomer_UI();
            break;
        case 6:
            consoleUI.GetCustomers_UI();
            break;
        case 7:
            consoleUI.UpdateCustomer_UI();
            break;
        case 8:
            consoleUI.DeleteCustomer_UI();
            break;
        case 9:
            Environment.Exit(0);    
            break;
        default:
            Console.WriteLine("CHOOSE FROM 1 - 9.");
            break;
    }

    Console.ReadKey();
}
