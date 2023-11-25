using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Models;
public record Product
{
        
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Product name is required")]
    [StringLength(280, ErrorMessage = "Product name is too long, max 280 characters")]
    [MinLength(1, ErrorMessage = "Product name is too short, min 1 characters")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Product short description is required")]
    [StringLength(500, ErrorMessage = "Product short description is too long, max 500 characters")]
    [MinLength(1, ErrorMessage = "Product short description is too short, min 1 characters")]
    public string ShortDescription { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Product description is required")]
    [StringLength(5000, ErrorMessage = "Product description is too long, max 5000 characters")]
    [MinLength(1, ErrorMessage = "Product description is too short, min 1 characters")]
    public string Description { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Product price is required")]
    [Range(0.01, 9999999999999999.99, ErrorMessage = "Product price must be between 0.01 and 9999999999999999.99")]
    [Column(TypeName = "decimal(16,2)")]
    public decimal Price { get; set; }
    
    [Range(0.01, 9999999999999999.99, ErrorMessage = "Product promotional price must be between 0.01 and 9999999999999999.99")]
    [Column(TypeName = "decimal(16,2)")]
    public decimal? PromotionalPrice { get; set; }
    
    [Required(ErrorMessage = "Product category is required")]
    [Range(1, 9999999999999999, ErrorMessage = "Product category must be between 1 and 9999999999999999")]
    public int CategoryId { get; set; }
    public ProductCategory? Category { get; set; }
    
    [Required(ErrorMessage = "Product brand is required")]
    [StringLength(280, ErrorMessage = "Product brand is too long, max 280 characters")]
    [MinLength(1, ErrorMessage = "Product brand is too short, min 1 characters")]
    public string Brand { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Product stock is required")]
    [Range(0, 9999999999999999, ErrorMessage = "Product stock must be between 0 and 9999999999999999")]
    public int Stock { get; set; }
    
    [Required(ErrorMessage = "Product bar code is required")]
    [StringLength(280, ErrorMessage = "Product bar code is too long, max 280 characters")]
    [MinLength(1, ErrorMessage = "Product bar code is too short, min 1 characters")]
    public string BarCode { get; set; } = string.Empty;
    
}