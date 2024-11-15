using Microsoft.EntityFrameworkCore;
using PantryTracker.Core.Interfaces;
using PantryTracker.Infrastructure;
using PantryTracker.Infrastructure.Data.Repositories;
using PantryTracker.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Database
builder.Services.AddDbContext<PantryContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<IFoodItemRepository, FoodItemRepository>();

// Services
builder.Services.AddScoped<IFoodItemService, FoodItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();