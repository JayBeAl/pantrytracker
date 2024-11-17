using PantryTracker.Web.Pages.ScanningSession.Models;

namespace PantryTracker.Web.Services;

public class ScanningSessionState
{
    public List<ScannedItem> ScannedItems { get; set; } = new();
    public DateTime StartTime { get; set; } = DateTime.Now;
    public int TotalScanned => ScannedItems.Count;
    public int NewItems => ScannedItems.Count(x => !x.ExistingItem);
    public int UpdatedItems => ScannedItems.Count(x => x.ExistingItem);
}