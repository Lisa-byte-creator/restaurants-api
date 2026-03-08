using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories{



public interface IRestaurantRepository

{
    Task<int> AddAsync(Restaurant restaurant);
    Task<int> Create(Restaurant entity);
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task Delete (Restaurant entity);
    Task SaveChangesAsync();
}}
