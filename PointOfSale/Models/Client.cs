using System.ComponentModel.DataAnnotations;

namespace PointOfSale.Models;

public record Client
{
    
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Client name is required")]
    [StringLength(280, ErrorMessage = "Client name is too long, max 280 characters")]
    [MinLength(1, ErrorMessage = "Client name is too short, min 1 characters")]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(500, ErrorMessage = "Client address is too long, max 500 characters")]
    [MinLength(1, ErrorMessage = "Client address is too short, min 1 characters")]
    public string? Address { get; set; } = string.Empty;
    
    [StringLength(280, ErrorMessage = "Client email is too long, max 280 characters")]
    [MinLength(1, ErrorMessage = "Client email is too short, min 1 characters")]
    public string? Email { get; set; } = string.Empty;
    
    [StringLength(280, ErrorMessage = "Client phone is too long, max 280 characters")]
    [MinLength(1, ErrorMessage = "Client phone is too short, min 1 characters")]
    public string? Phone { get; set; } = string.Empty;
    
    [StringLength(280, ErrorMessage = "Client document is too long, max 280 characters")]
    [MinLength(1, ErrorMessage = "Client document is too short, min 1 characters")]
    public string? Document { get; set; } = string.Empty;
}