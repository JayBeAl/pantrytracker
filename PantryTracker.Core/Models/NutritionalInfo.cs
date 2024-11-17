using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PantryTracker.Core.Models;

public class NutritionalInfo
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("FoodItem")]
    public int FoodItemId { get; set; }
    
    public decimal? EnergyKcal { get; set; }
    public decimal? Proteins { get; set; }
    public decimal? Carbohydrates { get; set; }
    public decimal? Fat { get; set; }
    
    public FoodItem FoodItem { get; set; }
}