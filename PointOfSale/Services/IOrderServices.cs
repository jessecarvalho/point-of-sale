using PointOfSale.Models;
using PointOfSale.Services.DTOs;

namespace PointOfSale.Services;

public interface IOrderServices
{
    IEnumerable<Order> GetAllOrders();
    Order GetOrderById(int id);
    Order CreateOrder(CreateOrderRequest request);
    Order UpdateOrder(int id, UpdateOrderRequest request);
    bool DeleteOrder(int id);
}