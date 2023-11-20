using PointOfSale.Models;
using PointOfSale.Services.DTOs;

namespace PointOfSale.Services;

public interface IProductCategoryService
{
    IEnumerable<ProductCategory> GetAllProductCategories();
    ProductCategory GetProductCategoryById(int id);
    ProductCategory CreateProductCategory(CreateProductCategoryRequest productCategory);
    ProductCategory UpdateProductCategory(int id, UpdateProductCategoryRequest productCategory);
    bool DeleteProductCategory(int id);
}