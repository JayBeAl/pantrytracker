using Microsoft.EntityFrameworkCore;
using PantryTracker.Core;

namespace PantryTracker.Infrastructure;

public class PantryContext : DbContext
{
    public DbSet<FoodItem> FoodItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=pantry.db");
}