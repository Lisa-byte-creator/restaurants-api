using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantDb");

        services.AddDbContext<RestaurantsDbContext>(options=>
        options.UseSqlServer(connectionString)
        .EnableSensitiveDataLogging());

        // Register repository
        services.AddScoped<IRestaurantRepository, RestaurantsRepository>();
         services.AddScoped<IDishesRepository, DishesRepository>();

        // Register seeder
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
    }
}