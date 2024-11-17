using System.ComponentModel.DataAnnotations;

namespace PantryTracker.Core.Models;

public class FoodItem
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string Barcode { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Brand { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string ImageUrl { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Category { get; set; } = string.Empty;
    
    [Required]
    public DateTime ExpiryDate { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string StorageLocation { get; set; } = string.Empty;
    
    public NutritionalInfo? NutritionalInfo { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
}