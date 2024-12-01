namespace PantryTracker.WebAuth.Components.ScanningSession.Enums;

public enum ScanningState
{
    Ready,
    Scanning,
    ProcessingItem,
    AwaitingDetails,
    Complete,
    Error
}