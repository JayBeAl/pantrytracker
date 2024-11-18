using System.ComponentModel.DataAnnotations;

namespace PantryTracker.Core.Models;

public class FoodItem
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Barcode { get; set; } = string.Empty;
    
    [Required]
    public int ProductId { get; set; }
    
    [Required]
    public DateTime ExpiryDate { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string StorageLocation { get; set; } = string.Empty;
    
    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    public ProductCache Product { get; set; } = null!;
}
