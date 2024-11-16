using System.Text.Json.Serialization;

namespace PantryTracker.Infrastructure.Models;

public class NutrimentsInfo
{
    [JsonPropertyName("energy-kcal_100g")]
    public decimal? EnergyKcal { get; set; }

    [JsonPropertyName("proteins_100g")]
    public decimal? Proteins { get; set; }

    [JsonPropertyName("carbohydrates_100g")]
    public decimal? Carbohydrates { get; set; }

    [JsonPropertyName("fat_100g")]
    public decimal? Fat { get; set; }
}