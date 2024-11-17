using System.Text.Json;
using Microsoft.JSInterop;

namespace PantryTracker.Web.Services;

public class SessionStorage
{
    private readonly IJSRuntime _jsRuntime;
    private const string SCANNING_SESSION_KEY = "current_scanning_session";

    public SessionStorage(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<ScanningSessionState> GetScanningSessionAsync()
    {
        var json = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", SCANNING_SESSION_KEY);
        return json == null ? new ScanningSessionState() : JsonSerializer.Deserialize<ScanningSessionState>(json);
    }

    public async Task SaveScanningSessionAsync(ScanningSessionState state)
    {
        var json = JsonSerializer.Serialize(state);
        await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", SCANNING_SESSION_KEY, json);
    }

    public async Task ClearScanningSessionAsync()
    {
        await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", SCANNING_SESSION_KEY);
    }
}