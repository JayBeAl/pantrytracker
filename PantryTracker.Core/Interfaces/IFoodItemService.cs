using PantryTracker.Core.Common;
using PantryTracker.Core.Models;

namespace PantryTracker.Core.Interfaces;

public interface IFoodItemService
{
    Task<Result<FoodItem>> GetByIdAsync(int id);
    Task<Result<FoodItem>> GetByBarcodeAsync(string barcode);
    Task<Result<IEnumerable<FoodItem>>> GetAllAsync();
    Task<Result<IEnumerable<FoodItem>>> GetExpiringItemsAsync(int daysThreshold);
    Task<Result<IEnumerable<FoodItem>>> GetLowStockItemsAsync(int threshold);
    Task<Result<IEnumerable<FoodItem>>> GetByStorageLocationAsync(string location);
    Task<Result<FoodItem>> AddFoodItemAsync(FoodItem item);
    Task<Result<bool>> UpdateFoodItemAsync(FoodItem item);
    Task<Result<bool>> UpdateQuantityAsync(int id, int newQuantity);
    Task<Result<bool>> DeleteFoodItemAsync(int id);
    Task<Result<bool>> CheckBarcodeExistsAsync(string barcode);
    Task<Result<FoodItem>> CreateFromOpenFoodFactsAsync(string barcode, int quantity, string storageLocation);
    Task<Result<FoodItem>> QuickAddWithDetailsAsync(string barcode, int quantity, string storageLocation, DateTime expiryDate);
}
