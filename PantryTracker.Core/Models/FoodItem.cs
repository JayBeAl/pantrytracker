namespace PantryTracker.Core.Models;

public class FoodItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public DateTime ExpiryDate { get; set; }
    public string StorageLocation { get; set; } = string.Empty;
    public NutritionalInfo? NutritionalInfo { get; set; }
    public int Quantity { get; set; }
}
