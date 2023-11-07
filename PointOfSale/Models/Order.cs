using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Models;

public class Order
{

    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Client is required")]
    [Range(1, 9999999999999999, ErrorMessage = "Client must be between 1 and 9999999999999999")]
    public int ClientId { get; set; }
    public Client? Client { get; set; }
    
    [Required(ErrorMessage = "Bill is required")]
    [Range(0.01, 9999999999999999.99, ErrorMessage = "Bill must be between 0.01 and 9999999999999999.99")]
    [Column(TypeName = "decimal(16,2)")]
    public decimal Bill { get; set; }
    
    [Required(ErrorMessage = "Paid is required")]
    public bool Paid { get; set; }    
    
    [Required(ErrorMessage = "Date is required")]
    public DateTime Date { get; set; }

}