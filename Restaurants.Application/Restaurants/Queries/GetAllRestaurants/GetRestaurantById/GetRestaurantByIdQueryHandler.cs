using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler
    : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
{
    private readonly ILogger<GetRestaurantByIdQueryHandler> _logger;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public GetRestaurantByIdQueryHandler(
        ILogger<GetRestaurantByIdQueryHandler> logger,
        IRestaurantRepository restaurantRepository,
        IMapper mapper)
    {
        _logger = logger;
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public async Task<RestaurantDto?> Handle(
        GetRestaurantByIdQuery request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting restaurant with id {Id}", request.Id);

        var restaurant =
            await _restaurantRepository.GetByIdAsync(request.Id);

        return _mapper.Map<RestaurantDto?>(restaurant);
    }
}
