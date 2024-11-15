using Microsoft.EntityFrameworkCore;
using PantryTracker.Core.Models;

namespace PantryTracker.Infrastructure;

public class PantryContext : DbContext
{
    public PantryContext(DbContextOptions<PantryContext> options)
        : base(options)
    {
    }

    public DbSet<FoodItem> FoodItems { get; set; }
    public DbSet<NutritionalInfo> NutritionalInfo { get; set; }
}
