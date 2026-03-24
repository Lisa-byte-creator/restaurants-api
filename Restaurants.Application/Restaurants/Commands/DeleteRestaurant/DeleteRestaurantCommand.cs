using MediatR;


namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommand(int id) : IRequest<Unit>

{
    public int Id {get;} = id;
}