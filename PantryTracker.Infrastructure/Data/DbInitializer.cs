using PantryTracker.Core.Models;

namespace PantryTracker.Infrastructure.Data;

public static class DbInitializer
{
    public static void Initialize(PantryContext context)
    {
        context.Database.EnsureCreated();

        // Check if DB has any items
        if (context.FoodItems.Any())
        {
            return;   // DB has been seeded
        }

        var foodItems = new[]
        {
            new FoodItem 
            { 
                Name = "Milk", 
                Quantity = 2,
                ExpiryDate = DateTime.Now.AddDays(7),
                StorageLocation = "Fridge",
                Barcode = "5901234123457"
            },
            new FoodItem 
            { 
                Name = "Bread", 
                Quantity = 1,
                ExpiryDate = DateTime.Now.AddDays(5),
                StorageLocation = "Pantry",
                Barcode = "4007624114711"
            },
            new FoodItem 
            { 
                Name = "Eggs", 
                Quantity = 12,
                ExpiryDate = DateTime.Now.AddDays(14),
                StorageLocation = "Fridge",
                Barcode = "0012345678905"
            }
        };

        context.FoodItems.AddRange(foodItems);
        context.SaveChanges();
    }
}
