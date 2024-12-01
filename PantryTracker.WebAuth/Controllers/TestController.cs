using Microsoft.AspNetCore.Mvc;
using PantryTracker.Core.Interfaces;

namespace PantryTracker.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IOpenFoodFactsService _openFoodFactsService;
    private readonly IFoodItemService _foodItemService;

    public TestController(IOpenFoodFactsService openFoodFactsService, IFoodItemService foodItemService)
    {
        _openFoodFactsService = openFoodFactsService;
        _foodItemService = foodItemService;
    }

    [HttpGet("product/{barcode}")]
    public async Task<IActionResult> GetProduct(string barcode)
    {
        var result = await _openFoodFactsService.GetProductByBarcodeAsync(barcode);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPost("quickadd/{barcode}")]
    public async Task<IActionResult> QuickAdd(string barcode)
    {
        var result = await _foodItemService.QuickAddWithDetailsAsync(
            barcode,
            quantity: 1,
            storageLocation: "Pantry",
            expiryDate: DateTime.Now.AddMonths(1)
        );

        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}