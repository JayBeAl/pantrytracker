using Microsoft.EntityFrameworkCore;
using PantryTracker.Core;
using PantryTracker.Core.Common;
using PantryTracker.Core.Interfaces;

namespace PantryTracker.Infrastructure.Data.Repositories;

public class FoodItemRepository : IFoodItemRepository
{
    private readonly PantryContext _context;

    public FoodItemRepository(PantryContext context)
    {
        _context = context;
    }

    public async Task<Result<FoodItem>> GetByIdAsync(int id)
    {
        var item = await _context.FoodItems
            .Include(f => f.NutritionalInfo)
            .FirstOrDefaultAsync(f => f.Id == id);

        return item == null 
            ? Result<FoodItem>.Failure($"FoodItem with ID {id} not found.") 
            : Result<FoodItem>.Success(item);
    }

    public async Task<Result<FoodItem>> GetByBarcodeAsync(string barcode)
    {
        var item = await _context.FoodItems
            .Include(f => f.NutritionalInfo)
            .FirstOrDefaultAsync(f => f.Barcode == barcode);

        return item == null 
            ? Result<FoodItem>.Failure($"FoodItem with barcode {barcode} not found.") 
            : Result<FoodItem>.Success(item);
    }

    public async Task<Result<IEnumerable<FoodItem>>> GetAllAsync()
    {
        var items = await _context.FoodItems
            .Include(f => f.NutritionalInfo)
            .ToListAsync();

        return Result<IEnumerable<FoodItem>>.Success(items);
    }

    public async Task<Result<IEnumerable<FoodItem>>> GetExpiringItemsAsync(int daysThreshold)
    {
        var thresholdDate = DateTime.Now.AddDays(daysThreshold);
        var items = await _context.FoodItems
            .Include(f => f.NutritionalInfo)
            .Where(f => f.ExpiryDate <= thresholdDate)
            .OrderBy(f => f.ExpiryDate)
            .ToListAsync();

        return Result<IEnumerable<FoodItem>>.Success(items);
    }

    public async Task<Result<IEnumerable<FoodItem>>> GetByStorageLocationAsync(string location)
    {
        var items = await _context.FoodItems
            .Include(f => f.NutritionalInfo)
            .Where(f => f.StorageLocation == location)
            .ToListAsync();

        return Result<IEnumerable<FoodItem>>.Success(items);
    }

    public async Task<Result<bool>> AddAsync(FoodItem foodItem)
    {
        try
        {
            await _context.FoodItems.AddAsync(foodItem);
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
        catch (DbUpdateException ex)
        {
            return Result<bool>.Failure($"Failed to add food item: {ex.Message}");
        }
    }

    public async Task<Result<bool>> UpdateAsync(FoodItem foodItem)
    {
        try
        {
            var existingItem = await _context.FoodItems
                .Include(f => f.NutritionalInfo)
                .FirstOrDefaultAsync(f => f.Id == foodItem.Id);

            if (existingItem == null)
                return Result<bool>.Failure($"FoodItem with ID {foodItem.Id} not found.");

            _context.Entry(existingItem).CurrentValues.SetValues(foodItem);
            
            if (foodItem.NutritionalInfo != null)
            {
                if (existingItem.NutritionalInfo == null)
                {
                    existingItem.NutritionalInfo = new NutritionalInfo();
                }
                _context.Entry(existingItem.NutritionalInfo)
                    .CurrentValues.SetValues(foodItem.NutritionalInfo);
            }

            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
        catch (DbUpdateException ex)
        {
            return Result<bool>.Failure($"Failed to update food item: {ex.Message}");
        }
    }

    public async Task<Result<bool>> DeleteAsync(int id)
    {
        try
        {
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null)
                return Result<bool>.Failure($"FoodItem with ID {id} not found.");

            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
        catch (DbUpdateException ex)
        {
            return Result<bool>.Failure($"Failed to delete food item: {ex.Message}");
        }
    }

    public async Task<Result<bool>> ExistsAsync(int id)
    {
        var exists = await _context.FoodItems.AnyAsync(f => f.Id == id);
        return Result<bool>.Success(exists);
    }
}
