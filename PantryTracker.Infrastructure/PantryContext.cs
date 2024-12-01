using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PantryTracker.Core.Models;

namespace PantryTracker.Infrastructure;

public class PantryContext : IdentityDbContext<ApplicationUser>
{
    public PantryContext(DbContextOptions<PantryContext> options) : base(options)
    {
    }

    public DbSet<FoodItem> FoodItems { get; set; }
    public DbSet<ProductCache> ProductCache { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductCache>()
            .HasIndex(p => p.Barcode)
            .IsUnique();

        modelBuilder.Entity<FoodItem>()
            .HasOne(f => f.Product)
            .WithMany()
            .HasForeignKey(f => f.ProductId)
            .IsRequired();
    }
}