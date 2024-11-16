using Microsoft.AspNetCore.Mvc;
using PantryTracker.Core.Interfaces;

namespace PantryTracker.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IOpenFoodFactsService _openFoodFactsService;

    public TestController(IOpenFoodFactsService openFoodFactsService)
    {
        _openFoodFactsService = openFoodFactsService;
    }

    [HttpGet("product/{barcode}")]
    public async Task<IActionResult> GetProduct(string barcode)
    {
        var result = await _openFoodFactsService.GetProductByBarcodeAsync(barcode);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}