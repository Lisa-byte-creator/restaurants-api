using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

public class RestaurantsRepository : IRestaurantRepository
{
    private readonly RestaurantsDbContext _dbContext;

    public RestaurantsRepository(RestaurantsDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<int> AddAsync(Restaurant restaurant)
{
    _dbContext.Restaurants.Add(restaurant);
    await _dbContext.SaveChangesAsync();
    return restaurant.Id;
}

    public async Task<int> Create(Restaurant entity)
    {
        _dbContext.Restaurants.Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Delete(Restaurant entity)
    {
        _dbContext.Restaurants.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        return await _dbContext.Restaurants.ToListAsync();
    }

    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        return await _dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

}