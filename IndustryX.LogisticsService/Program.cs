using IndustryX.LogisticsService.Core.Middlewares;
using IndustryX.LogisticsService.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddScoped<ShipmentService>();
builder.Services.AddSingleton<GeneralExceptionHandleMiddleware>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
// Configure the HTTP request pipeline.
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GeneralExceptionHandleMiddleware>();

app.MapControllers();

app.Run();