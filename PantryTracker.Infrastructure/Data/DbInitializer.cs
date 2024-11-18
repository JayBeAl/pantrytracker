using PantryTracker.Core.Models;

namespace PantryTracker.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(PantryContext context)
    {
        context.Database.EnsureCreated();

        if (context.FoodItems.Any())
        {
            return;   // DB has been seeded
        }

        var products = new[]
        {
            new ProductCache
            {
                Barcode = "5901234123457",
                Name = "Milk",
                Brand = "Dairy Farm",
                Category = "Dairy",
                CreatedAt = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                EnergyKcal = 42,
                Proteins = 3.4m,
                Carbohydrates = 5.0m,
                Fat = 1.5m
            },
            new ProductCache
            {
                Barcode = "4007624114711",
                Name = "Bread",
                Brand = "Baker's Best",
                Category = "Bakery",
                CreatedAt = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                EnergyKcal = 265,
                Proteins = 8.0m,
                Carbohydrates = 49.0m,
                Fat = 3.2m
            },
            new ProductCache
            {
                Barcode = "0012345678905",
                Name = "Eggs",
                Brand = "Farm Fresh",
                Category = "Dairy",
                CreatedAt = DateTime.UtcNow,
                LastUpdated = DateTime.UtcNow,
                EnergyKcal = 155,
                Proteins = 12.6m,
                Carbohydrates = 1.1m,
                Fat = 11.3m
            }
        };

        context.ProductCache.AddRange(products);
        context.SaveChanges();

        var foodItems = products.Select(p => new FoodItem 
        {
            Barcode = p.Barcode,
            ProductId = p.Id,
            Quantity = p.Barcode == "0012345678905" ? 12 : p.Barcode == "5901234123457" ? 2 : 1,
            ExpiryDate = DateTime.Now.AddDays(p.Barcode == "0012345678905" ? 14 : p.Barcode == "5901234123457" ? 7 : 5),
            StorageLocation = p.Category == "Dairy" ? "Fridge" : "Pantry",
            Product = p
        }).ToArray();

        context.FoodItems.AddRange(foodItems);
        context.SaveChanges();
    }
}
