using PantryTracker.Core.Common;
using PantryTracker.Core.Models;

namespace PantryTracker.Core.Interfaces;

public interface IProductService
{
    Task<Result<ProductCache>> GetByIdAsync(int id);
    Task<Result<ProductCache>> GetByBarcodeAsync(string barcode);
    Task<Result<IEnumerable<ProductCache>>> GetAllAsync();
    Task<Result<bool>> AddProductAsync(ProductCache product);
    Task<Result<bool>> UpdateProductAsync(ProductCache product);
    Task<Result<bool>> DeleteProductAsync(int id);
}