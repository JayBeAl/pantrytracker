using System.ComponentModel.DataAnnotations;

namespace PantryTracker.Core.Models;

public class ProductCache
{
    [Key]
    public string Barcode { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string ImageUrl { get; set; }
    public string Category { get; set; }
    public string? ServingSize { get; set; }
    public decimal? EnergyKcal { get; set; }
    public decimal? Proteins { get; set; }
    public decimal? Carbohydrates { get; set; }
    public decimal? Fat { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdated { get; set; }
}
