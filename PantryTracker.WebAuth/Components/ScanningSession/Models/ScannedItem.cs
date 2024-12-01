namespace PantryTracker.WebAuth.Components.ScanningSession.Models;

public class ScannedItem
{
    public string Barcode { get; set; }
    public string Name { get; set; }
    public DateTime Timestamp { get; set; }
    public bool IsProcessed { get; set; }
    public bool ExistingItem { get; set; }
}