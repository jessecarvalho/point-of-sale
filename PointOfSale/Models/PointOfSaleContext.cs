using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;

namespace PointOfSale.Models;

public class PointOfSaleContext: DbContext
{
    
    public PointOfSaleContext(DbContextOptions<PointOfSaleContext> options)
        : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductsCategories { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Client> Clients { get; set; }
    
    
    
}