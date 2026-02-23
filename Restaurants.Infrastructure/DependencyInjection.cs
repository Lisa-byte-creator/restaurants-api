using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)

    {
        services.AddDbContext<RestaurantsDbContext>(options =>
         options.UseSqlite(
        configuration.GetConnectionString("RestaurantsDb")));

        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

        return services;
    }
}
