using PantryTracker.Core.Common;
using PantryTracker.Core.Models;

namespace PantryTracker.Core.Interfaces;

public interface IOpenFoodFactsService
{
    Task<Result<ProductInfo>> GetProductByBarcodeAsync(string barcode);
}