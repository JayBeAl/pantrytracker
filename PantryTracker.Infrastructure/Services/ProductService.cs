using PantryTracker.Core.Common;
using PantryTracker.Core.Interfaces;
using PantryTracker.Core.Models;

public class ProductService : IProductService
{
    private readonly IProductCacheRepository _repository;

    public ProductService(IProductCacheRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ProductCache>> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Result<ProductCache>> GetByBarcodeAsync(string barcode)
    {
        return await _repository.GetByBarcodeAsync(barcode);
    }

    public async Task<Result<IEnumerable<ProductCache>>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Result<bool>> AddProductAsync(ProductCache product)
    {
        return await _repository.AddAsync(product);
    }

    public async Task<Result<bool>> UpdateProductAsync(ProductCache product)
    {
        return await _repository.UpdateAsync(product);
    }

    public async Task<Result<bool>> DeleteProductAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}