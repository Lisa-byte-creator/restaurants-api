using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Repositories;
using MediatR;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using AutoMapper;


namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurant;

public class GetDishesForRestaurantQueryHandler(ILogger<GetDishesForRestaurantQueryHandler>logger,
IRestaurantRepository restaurantRepository,
IMapper mapper) : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
{


public async Task<IEnumerable<DishDto>>Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
{
    logger.LogInformation("Retrieving Dishes for restaurant with id {RestaurantId}", request.RestaurantId);

    var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);

    if (restaurant == null) throw new NotFoundException(nameof (Restaurant), request.RestaurantId.ToString());

    var results = mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

    return results;
}
}