using PantryTracker.Core.Common;
using PantryTracker.Core.Models;

namespace PantryTracker.Core.Interfaces;

public interface IProductCacheRepository
{
    Task<Result<ProductCache>> GetByBarcodeAsync(string barcode);
    Task<Result<bool>> AddAsync(ProductCache product);
    Task<Result<bool>> ExistsAsync(string barcode);
}