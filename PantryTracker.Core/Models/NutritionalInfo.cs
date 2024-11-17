namespace PantryTracker.Core.Models;

public class NutritionalInfo
{
    public int Id { get; set; }  // This will be the primary key
    public int Energy { get; set; }
    public int Proteins { get; set; }
    public int Carbohydrates { get; set; }
    public int Fat { get; set; }
    
    public int FoodItemId { get; set; }  // Foreign key
    public FoodItem FoodItem { get; set; }
}