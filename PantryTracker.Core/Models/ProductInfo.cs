namespace PantryTracker.Core.Models;

public class ProductInfo
{
    public string Barcode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string ServingSize { get; set; } = string.Empty;
    public int? EnergyKcal { get; set; }
    public int? Proteins { get; set; }
    public int? Carbohydrates { get; set; }
    public int? Fat { get; set; }
}

