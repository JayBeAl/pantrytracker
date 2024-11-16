using System.Text.Json.Serialization;

namespace PantryTracker.Infrastructure.Models;

public class OpenFoodFactsProduct
{
    [JsonPropertyName("product_name")]
    public string ProductName { get; set; }

    [JsonPropertyName("brands")]
    public string Brands { get; set; }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }

    [JsonPropertyName("categories")]
    public string Categories { get; set; }

    [JsonPropertyName("serving_size")]
    public string ServingSize { get; set; }

    [JsonPropertyName("nutriments")]
    public NutrimentsInfo Nutriments { get; set; }
}