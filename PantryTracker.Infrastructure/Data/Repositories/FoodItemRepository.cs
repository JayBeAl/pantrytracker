using Microsoft.EntityFrameworkCore;
using PantryTracker.Core;
using PantryTracker.Core.Interfaces;

namespace PantryTracker.Infrastructure.Data.Repositories;

public class FoodItemRepository : IFoodItemRepository
{
    private readonly PantryContext _context;

    public FoodItemRepository(PantryContext context)
    {
        _context = context;
    }

    public async Task<FoodItem?> GetByIdAsync(int id)
    {
        return await _context.FoodItems
            .Include(f => f.NutritionalInfo)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<FoodItem?> GetByBarcodeAsync(string barcode)
    {
        return await _context.FoodItems
            .Include(f => f.NutritionalInfo)
            .FirstOrDefaultAsync(f => f.Barcode == barcode);
    }

    public async Task<IEnumerable<FoodItem>> GetAllAsync()
    {
        return await _context.FoodItems
            .Include(f => f.NutritionalInfo)
            .ToListAsync();
    }

    public async Task<IEnumerable<FoodItem>> GetExpiringItemsAsync(int daysThreshold)
    {
        var thresholdDate = DateTime.Now.AddDays(daysThreshold);
        return await _context.FoodItems
            .Include(f => f.NutritionalInfo)
            .Where(f => f.ExpiryDate <= thresholdDate)
            .OrderBy(f => f.ExpiryDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<FoodItem>> GetByStorageLocationAsync(string location)
    {
        return await _context.FoodItems
            .Include(f => f.NutritionalInfo)
            .Where(f => f.StorageLocation == location)
            .ToListAsync();
    }

    public async Task AddAsync(FoodItem foodItem)
    {
        await _context.FoodItems.AddAsync(foodItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FoodItem foodItem)
    {
        var existingItem = await GetByIdAsync(foodItem.Id);
        if (existingItem != null)
        {
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
        }
    }

    public async Task DeleteAsync(int id)
    {
        var foodItem = await GetByIdAsync(id);
        if (foodItem != null)
        {
            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.FoodItems.AnyAsync(f => f.Id == id);
    }
}