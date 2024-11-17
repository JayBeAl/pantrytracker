namespace PantryTracker.Web.Pages.ScanningSession.Enums;

public enum ScanningState
{
    Ready,
    Scanning,
    ProcessingItem,
    AwaitingDetails,
    Complete,
    Error
}
