using PantryTracker.Core.Models;

namespace PantryTracker.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(PantryContext context)
{
    context.Database.EnsureCreated();

    if (context.ProductCache.Any())
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

    var foodItems = new[]
    {
        new FoodItem
        {
            ProductId = products[0].Id,
            Quantity = 2,
            ExpiryDate = DateTime.Now.AddDays(7),
            StorageLocation = "Fridge"
        },
        new FoodItem
        {
            ProductId = products[1].Id,
            Quantity = 1,
            ExpiryDate = DateTime.Now.AddDays(5),
            StorageLocation = "Pantry"
        },
        new FoodItem
        {
            ProductId = products[2].Id,
            Quantity = 12,
            ExpiryDate = DateTime.Now.AddDays(14),
            StorageLocation = "Fridge"
        }
    };

    context.FoodItems.AddRange(foodItems);
    context.SaveChanges();
}
}
