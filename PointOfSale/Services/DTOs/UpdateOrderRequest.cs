using PointOfSale.Models;

namespace PointOfSale.Services.DTOs;

public class UpdateOrderRequest
{
    public decimal Bill { get; set; } = 0;
    public bool Paid { get; set; } = false;
    public DateTime Date { get; set; } = DateTime.Now;
}