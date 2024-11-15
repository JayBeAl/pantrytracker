namespace PantryTracker.Core;

public class FoodItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string StorageLocation { get; set; }
    public NutritionalInfo? NutritionalInfo { get; set; }
    public int Quantity { get; set; }
}
