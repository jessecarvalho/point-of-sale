using PointOfSale.Models;
using PointOfSale.Services.DTOs;

namespace PointOfSale.Services;

public class ProductCategoryService : IProductCategoryService
{
    private readonly PointOfSaleContext _context;

    public ProductCategoryService(PointOfSaleContext context)
    {
        _context = context;
    }

    public IEnumerable<ProductCategory> GetAllProductCategories()
    {
        var productCategory = _context.ProductsCategories.ToList();
        return productCategory;
    }

    public ProductCategory GetProductCategoryById(int id)
    {
        var productCategory = _context.ProductsCategories.Find(id);
        if (productCategory == null)
        {
            throw new Exception("Product Category not found");
        }
        return productCategory;
    }

    public ProductCategory CreateProductCategory(CreateProductCategoryRequest request)
    {
        var productCategory = new ProductCategory
        {
            Name = request.Name,
            Description = request.Description
        };
        _context.ProductsCategories.Add(productCategory);
        _context.SaveChanges();
        return productCategory;
    }

    public ProductCategory UpdateProductCategory(int id, UpdateProductCategoryRequest request)
    {
        var productCategory = _context.ProductsCategories.Find(id);
        if (productCategory == null)
        {
            throw new Exception("Product Category not found");
        }
        productCategory.Name = request.Name;
        productCategory.Description = request.Description;
        _context.SaveChanges();
        return productCategory;
    }

    public bool DeleteProductCategory(int id)
    {
        var productCategory = _context.ProductsCategories.Find(id);
        if (productCategory == null)
        {
            throw new Exception("Product Category not found");
        }

        _context.ProductsCategories.Remove(productCategory);
        return true;
    }
}