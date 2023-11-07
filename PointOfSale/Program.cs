using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PointOfSaleContext>(options =>
{
    options.UseSqlServer("Server=pc-da-nasa\\SQLEXPRESS;Database=ecommerce;Trusted_Connection=True;TrustServerCertificate=true;");
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();
    
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();