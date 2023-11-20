using PointOfSale.Models;
using PointOfSale.Services.DTOs;

namespace PointOfSale.Services;

public class ProductService : IProductService
{
    
    private readonly PointOfSaleContext _context;

    public ProductService(PointOfSaleContext context)
    {
        _context = context;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product GetProductById(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        return product;
    }

    public Product CreateProduct(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            ShortDescription = request.ShortDescription,
            Description = request.ShortDescription,
            Price = request.Price,
            PromotionalPrice = request.PromotionalPrice,
            CategoryId = request.CategoryId,
            Brand = request.Brand,
            Stock = request.Stock,
            BarCode = request.BarCode 
        };
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Product UpdateProduct(int id, UpdateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            ShortDescription = request.ShortDescription,
            Description = request.ShortDescription,
            Price = request.Price,
            PromotionalPrice = request.PromotionalPrice,
            CategoryId = request.CategoryId,
            Brand = request.Brand,
            Stock = request.Stock,
            BarCode = request.BarCode
        };
        _context.Products.Update(product);
        _context.SaveChanges();
        return product;
    }

    public bool DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            throw new Exception("Product not found");
        }

        _context.Products.Remove(product);
        _context.SaveChanges();
        return true;
    }
    
}