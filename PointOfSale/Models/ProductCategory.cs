using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models;

public record ProductCategory
{
    
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Product category name is required")]
    [StringLength(280, ErrorMessage = "Product category name is too long, max 280 characters")]
    [MinLength(1, ErrorMessage = "Product category name is too short, min 1 characters")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Product category description is required")]
    [StringLength(500, ErrorMessage = "Product category description is too long, max 500 characters")]
    [MinLength(1, ErrorMessage = "Product category description is too short, min 1 characters")]
    public string Description { get; set; } = string.Empty;
    
}