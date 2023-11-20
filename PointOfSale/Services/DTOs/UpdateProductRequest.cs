namespace PointOfSale.Services.DTOs;

public class UpdateProductRequest
{
    public string Name { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public decimal? PromotionalPrice { get; set; }
    public int CategoryId { get; set; } = 0;
    public string Brand { get; set; } = string.Empty;
    public int Stock { get; set; } = 0;
    public string BarCode { get; set; } = string.Empty;
}