using System.Text.Json.Serialization;

namespace PantryTracker.Infrastructure.Models;

public class OpenFoodFactsResponse
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("product")]
    public OpenFoodFactsProduct Product { get; set; }
}