using PointOfSale.Models;

namespace PointOfSale.Services.DTOs;

public class CreateOrderProductRequest
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total { get; set; }
}