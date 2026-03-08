using MediatR;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommand : IRequest<bool>
{
    public int Id { get; set; }

    public string Name { get; init; } = default!;
    public string Description { get; init; } = default!;
    public bool HasDelivery { get; set; }
}
