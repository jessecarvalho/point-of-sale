using PointOfSale.Models;
using PointOfSale.Services.DTOs;

namespace PointOfSale.Services;

public class OrderProductServices
{

    private readonly PointOfSaleContext _context;

    public OrderProductServices(PointOfSaleContext context)
    {
        _context = context;
    }
    
    public IEnumerable<OrderProduct> GetAllOrderProducts()
    {
        var orderProduct = _context.OrderProducts.ToList();
        return orderProduct;
    }
    
    public OrderProduct GetOrderProductById(int id)
    {
        var orderProduct = _context.OrderProducts.Find(id);
        if (orderProduct == null)
        {
            throw new Exception("Order Product not found");
        }
        return orderProduct;
    }
    
    public OrderProduct CreateOrderProduct(CreateOrderProductRequest request)
    {
        var orderProduct = new OrderProduct
        {
            OrderId = request.OrderId,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            Price = request.Price
        };
        _context.OrderProducts.Add(orderProduct);
        _context.SaveChanges();
        return orderProduct;
    }
    
    public OrderProduct UpdateOrderProduct(int id, UpdateOrderProductRequest request)
    {
        var orderProduct = _context.OrderProducts.Find(id);
        if (orderProduct == null)
        {
            throw new Exception("Order Product not found");
        }
        orderProduct.OrderId = request.OrderId;
        orderProduct.ProductId = request.ProductId;
        orderProduct.Quantity = request.Quantity;
        orderProduct.Price = request.Price;
        _context.SaveChanges();
        return orderProduct;
    }
    
    public bool DeleteOrderProduct(int id)
    {
        var orderProduct = _context.OrderProducts.Find(id);
        if (orderProduct == null)
        {
            throw new Exception("Order Product not found");
        }
        _context.OrderProducts.Remove(orderProduct);
        _context.SaveChanges();
        return true;
    }

}