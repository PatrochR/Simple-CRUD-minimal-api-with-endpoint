global using Microsoft.EntityFrameworkCore;
global using CRUD_Minimal_api.Models;
global using CRUD_Minimal_api.Data;
global using CRUD_Minimal_api.Endpoints;
global using CRUD_Minimal_api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options => 
{
    options.UseSqlite("Data Source=Customer");
});

builder.Services.AddScoped<ICustomerRepository , CustomerRepository>();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapCustomer();


app.Run();
