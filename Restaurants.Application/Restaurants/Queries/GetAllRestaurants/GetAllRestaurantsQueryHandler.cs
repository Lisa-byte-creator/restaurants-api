using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler
    : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
{
    private readonly ILogger<GetAllRestaurantsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IRestaurantRepository _restaurantsRepository;

    public GetAllRestaurantsQueryHandler(
        ILogger<GetAllRestaurantsQueryHandler> logger,
        IMapper mapper,
        IRestaurantRepository restaurantsRepository)
    {
        _logger = logger;
        _mapper = mapper;
        _restaurantsRepository = restaurantsRepository;
    }

    public async Task<IEnumerable<RestaurantDto>> Handle(
        GetAllRestaurantsQuery request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all restaurants");

        var restaurants = await _restaurantsRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
    }
}
