using MediatR;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Restaurants.Domain.Repositories;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(
    ILogger<CreateDishCommandHandler> logger,
    IRestaurantRepository restaurantsRepository,
    IDishesRepository dishesRepository,
    IMapper mapper
) : IRequestHandler<CreateDishCommand, int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new dish: {@DishRequest}", request);

        var restaurant = await restaurantsRepository.GetByIdAsync(request.RestaurantId);

        if (restaurant == null)
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

        var dish = mapper.Map<Dish>(request);

        await dishesRepository.Create(dish);

        return await dishesRepository.Create(dish);
    }
}