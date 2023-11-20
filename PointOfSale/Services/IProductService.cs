using PointOfSale.Models;
using PointOfSale.Services.DTOs;

namespace PointOfSale.Services;

public interface IProductService
{
    IEnumerable<Product> GetAllProducts();
    Product GetProductById(int id);
    Product CreateProduct(CreateProductRequest product);
    Product UpdateProduct(int id, UpdateProductRequest product);
    bool DeleteProduct(int id);
}