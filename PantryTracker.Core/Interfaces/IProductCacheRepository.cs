using PantryTracker.Core.Common;
using PantryTracker.Core.Models;

namespace PantryTracker.Core.Interfaces;

public interface IProductCacheRepository
{
    Task<Result<ProductCache>> GetByBarcodeAsync(string barcode);
    Task<Result<ProductCache>> GetByIdAsync(int id);
    Task<Result<IEnumerable<ProductCache>>> GetAllAsync();
    Task<Result<bool>> AddAsync(ProductCache product);
    Task<Result<bool>> UpdateAsync(ProductCache product);
    Task<Result<bool>> ExistsAsync(string barcode);
    Task<Result<bool>> ExistsByIdAsync(int id);
}