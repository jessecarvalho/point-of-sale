using PointOfSale.Services.DTOs;

namespace PointOfSale.Services;
using PointOfSale.Models;

public class OrderServices : IOrderServices
{
    
    private readonly PointOfSaleContext _context;

    public OrderServices(PointOfSaleContext context)
    {
        _context = context;
    }

    public IEnumerable<Order> GetAllOrders()
    {
        return _context.Orders.ToList();
    }

    public Order GetOrderById(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            throw new Exception("Order not found");
        }
        return order;
    }
    
    public Order CreateOrder(CreateOrderRequest request)
    {
        var order = new Order
        {
            ClientId = request.ClientId,
            Bill = request.Bill,
            Paid = request.Paid,
            Date = request.Date
        };
        _context.Orders.Add(order);
        _context.SaveChanges();
        return order;
    }

    public Order UpdateOrder(int id, UpdateOrderRequest request)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            throw new Exception("Order not found");
        }
        order.Bill = request.Bill;
        order.Paid = request.Paid;
        order.Date = request.Date;
        _context.SaveChanges();
        return order;
    }

    public bool DeleteOrder(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null)
        {
            throw new Exception("Order not found");
        }

        _context.Orders.Remove(order);
        _context.SaveChanges();
        return true;
    }
    
}