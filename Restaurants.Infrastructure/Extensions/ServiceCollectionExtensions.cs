using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        // Register repository
        services.AddScoped<IRestaurantRepository, RestaurantsRepository>();

        // Register seeder
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
    }
}