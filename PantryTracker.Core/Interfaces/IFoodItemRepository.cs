namespace PantryTracker.Core.Interfaces;

public interface IFoodItemRepository
{
    Task<FoodItem?> GetByIdAsync(int id);
    Task<FoodItem?> GetByBarcodeAsync(string barcode);
    Task<IEnumerable<FoodItem>> GetAllAsync();
    Task<IEnumerable<FoodItem>> GetExpiringItemsAsync(int daysThreshold);
    Task<IEnumerable<FoodItem>> GetByStorageLocationAsync(string location);
    Task AddAsync(FoodItem foodItem);
    Task UpdateAsync(FoodItem foodItem);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}