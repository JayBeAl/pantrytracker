using Microsoft.EntityFrameworkCore;
using PantryTracker.Core.Common;
using PantryTracker.Core.Interfaces;
using PantryTracker.Core.Models;

namespace PantryTracker.Infrastructure.Data.Repositories;

public class ProductCacheRepository : IProductCacheRepository
{
    private readonly PantryContext _context;

    public ProductCacheRepository(PantryContext context)
    {
        _context = context;
    }

    public async Task<Result<ProductCache>> GetByBarcodeAsync(string barcode)
    {
        var product = await _context.ProductCache
            .FirstOrDefaultAsync(p => p.Barcode == barcode);
            
        return product == null 
            ? Result<ProductCache>.Failure($"Product with barcode {barcode} not found in cache") 
            : Result<ProductCache>.Success(product);
    }

    public async Task<Result<ProductCache>> GetByIdAsync(int id)
    {
        var product = await _context.ProductCache.FindAsync(id);
        return product == null 
            ? Result<ProductCache>.Failure($"Product with id {id} not found in cache") 
            : Result<ProductCache>.Success(product);
    }

    public async Task<Result<bool>> AddAsync(ProductCache product)
    {
        try
        {
            await _context.ProductCache.AddAsync(product);
            await _context.SaveChangesAsync();
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure($"Failed to add product to cache: {ex.Message}");
        }
    }

    public async Task<Result<bool>> ExistsAsync(string barcode)
    {
        var exists = await _context.ProductCache.AnyAsync(p => p.Barcode == barcode);
        return Result<bool>.Success(exists);
    }
}
