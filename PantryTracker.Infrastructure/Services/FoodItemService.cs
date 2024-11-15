using PantryTracker.Core.Common;
using PantryTracker.Core.Interfaces;
using PantryTracker.Core.Models;

namespace PantryTracker.Infrastructure.Services;

public class FoodItemService : IFoodItemService
{
    private readonly IFoodItemRepository _repository;

    public FoodItemService(IFoodItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<FoodItem>> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Result<FoodItem>> GetByBarcodeAsync(string barcode)
    {
        if (string.IsNullOrWhiteSpace(barcode))
            return Result<FoodItem>.Failure("Barcode cannot be empty.");

        return await _repository.GetByBarcodeAsync(barcode);
    }

    public async Task<Result<IEnumerable<FoodItem>>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Result<IEnumerable<FoodItem>>> GetExpiringItemsAsync(int daysThreshold)
    {
        if (daysThreshold < 0)
            return Result<IEnumerable<FoodItem>>.Failure("Days threshold must be positive.");

        return await _repository.GetExpiringItemsAsync(daysThreshold);
    }

    public async Task<Result<IEnumerable<FoodItem>>> GetLowStockItemsAsync(int threshold)
    {
        if (threshold < 0)
            return Result<IEnumerable<FoodItem>>.Failure("Threshold must be positive.");

        var itemsResult = await _repository.GetAllAsync();
        if (!itemsResult.IsSuccess)
            return Result<IEnumerable<FoodItem>>.Failure(itemsResult.Error);

        var lowStockItems = itemsResult.Value.Where(item => item.Quantity <= threshold);
        return Result<IEnumerable<FoodItem>>.Success(lowStockItems);
    }

    public async Task<Result<IEnumerable<FoodItem>>> GetByStorageLocationAsync(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
            return Result<IEnumerable<FoodItem>>.Failure("Location cannot be empty.");

        return await _repository.GetByStorageLocationAsync(location);
    }

    public async Task<Result<FoodItem>> AddFoodItemAsync(FoodItem item)
    {
        var validationResult = ValidateFoodItem(item);
        if (!validationResult.IsSuccess)
            return Result<FoodItem>.Failure(validationResult.Error);

        if (item.Id != 0)
            return Result<FoodItem>.Failure("New item should not have an ID.");

        var addResult = await _repository.AddAsync(item);
        return addResult.IsSuccess 
            ? Result<FoodItem>.Success(item) 
            : Result<FoodItem>.Failure(addResult.Error);
    }

    public async Task<Result<bool>> UpdateFoodItemAsync(FoodItem item)
    {
        var validationResult = ValidateFoodItem(item);
        if (!validationResult.IsSuccess)
            return Result<bool>.Failure(validationResult.Error);

        var existsResult = await _repository.ExistsAsync(item.Id);
        if (!existsResult.IsSuccess)
            return Result<bool>.Failure(existsResult.Error);

        if (!existsResult.Value)
            return Result<bool>.Failure($"FoodItem with ID {item.Id} not found.");

        return await _repository.UpdateAsync(item);
    }

    public async Task<Result<bool>> UpdateQuantityAsync(int id, int newQuantity)
    {
        if (newQuantity < 0)
            return Result<bool>.Failure("Quantity cannot be negative.");

        var itemResult = await _repository.GetByIdAsync(id);
        if (!itemResult.IsSuccess)
            return Result<bool>.Failure(itemResult.Error);

        var item = itemResult.Value;
        item.Quantity = newQuantity;
        return await _repository.UpdateAsync(item);
    }

    public async Task<Result<bool>> DeleteFoodItemAsync(int id)
    {
        var existsResult = await _repository.ExistsAsync(id);
        if (!existsResult.IsSuccess)
            return Result<bool>.Failure(existsResult.Error);

        if (!existsResult.Value)
            return Result<bool>.Failure($"FoodItem with ID {id} not found.");

        return await _repository.DeleteAsync(id);
    }

    private Result<bool> ValidateFoodItem(FoodItem item)
    {
        if (string.IsNullOrWhiteSpace(item.Name))
            return Result<bool>.Failure("Name is required.");

        if (item.ExpiryDate < DateTime.Now)
            return Result<bool>.Failure("Expiry date cannot be in the past.");

        if (item.Quantity < 0)
            return Result<bool>.Failure("Quantity cannot be negative.");

        if (string.IsNullOrWhiteSpace(item.StorageLocation))
            return Result<bool>.Failure("Storage location is required.");

        return Result<bool>.Success(true);
    }
}
