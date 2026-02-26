using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantsRepository : IRestaurantsRepository
{
    private readonly RestaurantsDbContext dbContext;

    public RestaurantsRepository(RestaurantsDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        return await dbContext.Restaurants.ToListAsync();
    }

    public async Task<Restaurant?>GetbyIdAsync(int id){
        var restaurant = await dbContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
        return restaurant;
    }

 
}