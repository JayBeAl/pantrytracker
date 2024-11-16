namespace PantryTracker.Web.Pages.ScanningSession.Models;

public class ItemDetails
{
    public int Quantity { get; set; } = 1;
    public string StorageLocation { get; set; }
    public DateTime ExpiryDate { get; set; } = DateTime.Now.AddMonths(1);
}