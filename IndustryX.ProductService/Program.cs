using IndustryX.ProductService.Core.Interfaces;
using IndustryX.ProductService.Infrastructure.Data;
using IndustryX.ProductService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//PostgreSQL connection string
var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

//DbContext and Repositories add
builder.Services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
// app.UseAuthorization();

app.MapControllers();

app.Run();
