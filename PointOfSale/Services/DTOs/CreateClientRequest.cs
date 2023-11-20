namespace PointOfSale.Services.DTOs;

public class CreateClientRequest
{
    public string Name { get; set; } = string.Empty;
    
    public string? Address { get; set; } = string.Empty;
    
    public string? Email { get; set; } = string.Empty;
    
    public string? Phone { get; set; } = string.Empty;
    
    public string? Document { get; set; } = string.Empty;
}
