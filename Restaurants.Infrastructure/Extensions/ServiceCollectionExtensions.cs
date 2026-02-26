using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<RestaurantsDbContext>(options =>
            options.UseInMemoryDatabase("RestaurantsDb"));

        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();

        //  register the seeder
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();

        return services;
    }
}