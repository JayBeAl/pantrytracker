using PantryTracker.Core.Common;
using PantryTracker.Core.Models;

namespace PantryTracker.Core.Interfaces;

public interface IFoodItemRepository
{
    Task<Result<FoodItem>> GetByIdAsync(int id);
    Task<Result<FoodItem>> GetByBarcodeAsync(string barcode);
    Task<Result<IEnumerable<FoodItem>>> GetAllAsync();
    Task<Result<IEnumerable<FoodItem>>> GetExpiringItemsAsync(int daysThreshold);
    Task<Result<IEnumerable<FoodItem>>> GetByStorageLocationAsync(string location);
    Task<Result<IEnumerable<FoodItem>>> GetByCategoryAsync(string category);
    Task<Result<IEnumerable<string>>> GetAllCategoriesAsync();
    Task<Result<IEnumerable<string>>> GetAllLocationsAsync();
    Task<Result<bool>> AddAsync(FoodItem foodItem);
    Task<Result<bool>> UpdateAsync(FoodItem foodItem);
    Task<Result<bool>> DeleteAsync(int id);
    Task<Result<bool>> ExistsAsync(int id);
}