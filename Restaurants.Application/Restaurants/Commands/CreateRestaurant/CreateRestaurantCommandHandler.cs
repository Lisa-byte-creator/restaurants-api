using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler
    : IRequestHandler<CreateRestaurantCommand, int>
{
    private readonly ILogger<CreateRestaurantCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IRestaurantRepository _restaurantsRepository;

    public CreateRestaurantCommandHandler(
        ILogger<CreateRestaurantCommandHandler> logger,
        IMapper mapper,
        IRestaurantRepository restaurantRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _restaurantsRepository = restaurantRepository;
    }

    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating restaurant");

        var restaurant = _mapper.Map<Restaurant>(request);

        return await _restaurantsRepository.AddAsync(restaurant);
    }
}
