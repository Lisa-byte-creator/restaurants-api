using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Restaurants.Application.Restaurants;

public class RestaurantsService : IRestaurantsService
{
    private readonly IRestaurantsRepository restaurantsRepository;
    private readonly ILogger<RestaurantsService> logger;

    public RestaurantsService(
        IRestaurantsRepository restaurantsRepository,
        ILogger<RestaurantsService> logger)
    {
        this.restaurantsRepository = restaurantsRepository;
        this.logger = logger;
    }

    public async Task<IEnumerable<Restaurant?>> GetAllRestaurants()
    {
        logger.LogInformation($"Getting all Restaurants{id}");

        var restaurant = await restaurantsRepository.GetbyIdAsync(id);

        return await restaurantsRepository.GetAllAsync();
    }
}