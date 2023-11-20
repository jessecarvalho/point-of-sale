using PointOfSale.Models;
using PointOfSale.Services.DTOs;

namespace PointOfSale.Services;

public interface IOrderProductServices
{
    IEnumerable<OrderProduct> GetAllOrderProducts();
    OrderProduct GetOrderProductById(int id);
    OrderProduct CreateOrderProduct(CreateOrderProductRequest request);
    OrderProduct UpdateOrderProduct(int id, UpdateOrderProductRequest request);
    bool DeleteOrderProduct(int id);
}