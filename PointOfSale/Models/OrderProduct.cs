using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Models;

public record OrderProduct
{

    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Order is required")]
    [Range(1, 9999999999999999, ErrorMessage = "Order must be between 1 and 9999999999999999")]
    public int OrderId { get; set; }
    public Order? Order { get; set; }
    
    [Required(ErrorMessage = "Product is required")]
    [Range(1, 9999999999999999, ErrorMessage = "Product must be between 1 and 9999999999999999")]
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    
    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 9999999999999999, ErrorMessage = "Quantity must be between 1 and 9999999999999999")]
    public int Quantity { get; set; }
    
    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, 9999999999999999.99, ErrorMessage = "Price must be between 0.01 and 9999999999999999.99")]
    [Column(TypeName = "decimal(16,2)")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Total is required")]
    [Range(0.01, 9999999999999999.99, ErrorMessage = "Total must be between 0.01 and 9999999999999999.99")]
    [Column(TypeName = "decimal(16,2)")]
    public decimal Total { get; set; }
    
}