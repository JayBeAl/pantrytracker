using System.ComponentModel.DataAnnotations;

namespace PantryTracker.Core.Models;

public class ProductCache
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Barcode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string? ServingSize { get; set; }
    public decimal? EnergyKcal { get; set; }
    public decimal? Proteins { get; set; }
    public decimal? Carbohydrates { get; set; }
    public decimal? Fat { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
}