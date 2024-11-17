using System.Net.Http.Json;
using System.Text.Json;
using PantryTracker.Core.Common;
using PantryTracker.Core.Interfaces;
using PantryTracker.Core.Models;
using PantryTracker.Infrastructure.Models;

namespace PantryTracker.Infrastructure.Services;

public class OpenFoodFactsService : IOpenFoodFactsService
{
    private readonly HttpClient _httpClient;
    private readonly IProductCacheRepository _cacheRepository;
    private const string BaseUrl = "https://world.openfoodfacts.org/api/v2/product/";

    public OpenFoodFactsService(HttpClient httpClient, IProductCacheRepository cacheRepository)
    {
        _httpClient = httpClient;
        _cacheRepository = cacheRepository;
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "PantryTracker - Android - Version 1.0");
    }

    public async Task<Result<ProductInfo>> GetProductByBarcodeAsync(string barcode)
    {
        if (string.IsNullOrWhiteSpace(barcode))
        {
            return Result<ProductInfo>.Failure("Barcode cannot be empty");
        }

        var cachedResult = await _cacheRepository.GetByBarcodeAsync(barcode);
        if (cachedResult.IsSuccess)
        {
            return Result<ProductInfo>.Success(MapToProductInfo(cachedResult.Value));
        }

        try
        {
            var response = await _httpClient.GetFromJsonAsync<OpenFoodFactsResponse>($"{BaseUrl}{barcode}");
            
            if (response == null)
            {
                return Result<ProductInfo>.Failure("Invalid response from OpenFoodFacts API");
            }

            if (response.Status != 1)
            {
                return Result<ProductInfo>.Failure($"Product with barcode {barcode} not found in OpenFoodFacts database");
            }

            if (string.IsNullOrWhiteSpace(response.Product?.ProductName))
            {
                return Result<ProductInfo>.Failure("Product data is incomplete");
            }

            var product = new ProductCache
            {
                Barcode = barcode,
                Name = response.Product.ProductName,
                Brand = response.Product.Brands ?? "Unknown",
                ImageUrl = response.Product.ImageUrl,
                Category = response.Product.Categories ?? "Unknown",
                ServingSize = response.Product.ServingSize,
                EnergyKcal = response.Product.Nutriments.EnergyKcal,
                Proteins = response.Product.Nutriments.Proteins,
                Carbohydrates = response.Product.Nutriments.Carbohydrates,
                Fat = response.Product.Nutriments.Fat,
                CreatedAt = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow
            };

            await _cacheRepository.AddAsync(product);
            return Result<ProductInfo>.Success(MapToProductInfo(product));
        }
        catch (HttpRequestException ex)
        {
            return Result<ProductInfo>.Failure($"Network error: {ex.Message}");
        }
        catch (JsonException ex)
        {
            return Result<ProductInfo>.Failure($"Invalid response format: {ex.Message}");
        }
        catch (Exception ex)
        {
            return Result<ProductInfo>.Failure($"Unexpected error: {ex.Message}");
        }
    }

    private static ProductInfo MapToProductInfo(ProductCache cache)
    {
        return new ProductInfo
        {
            Barcode = cache.Barcode,
            Name = cache.Name,
            Brand = cache.Brand,
            ImageUrl = cache.ImageUrl,
            Category = cache.Category,
            ServingSize = cache.ServingSize,
            EnergyKcal = (int?)cache.EnergyKcal,
            Proteins = (int?)cache.Proteins,
            Carbohydrates = (int?)cache.Carbohydrates,
            Fat = (int?)cache.Fat
        };
    }

}
