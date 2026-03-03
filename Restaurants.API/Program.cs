using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

// Register DbContext
builder.Services.AddDbContext<RestaurantsDbContext>(options =>
    options.UseSqlite("Data Source=restaurants.db")); // or UseSqlServer(...)

// Register seeder
builder.Services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

var app = builder.Build();

// Run seeder
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
    await seeder.Seed();
}

// Configure pipeline
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();