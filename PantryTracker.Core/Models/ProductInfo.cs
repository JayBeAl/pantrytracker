namespace PantryTracker.Core.Models;

public class ProductInfo
{
    public string Barcode { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string ImageUrl { get; set; }
    public string Category { get; set; }
    public string ServingSize { get; set; }
    public int? EnergyKcal { get; set; }
    public int? Proteins { get; set; }
    public int? Carbohydrates { get; set; }
    public int? Fat { get; set; }
}

