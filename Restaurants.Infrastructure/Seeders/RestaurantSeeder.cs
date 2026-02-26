using Restaurants.Infrastructure.Persistence;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext): IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();

            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        

        List<Restaurant> restaurants = new List<Restaurant>
{
    new Restaurant
    {
        Id = 1,
        Name = "Ocean Breeze Grill",
        Description = "Fresh seafood and grilled specialties with a coastal vibe.",
        Category = "Seafood",
        HasDelivery = true,
        ContactEmail = "info@oceanbreeze.com",
        ContactNumber = "+27 11 456 7890",
        Address = new Address
        {
            Street = "12 Beach Road",
            City = "Cape Town",
            Postalcode = "8001",
        },
        Dishes = new List<Dish>
        {
            new Dish
            {
                Name = "Grilled Kingklip",
                Description = "Served with lemon butter sauce and seasonal vegetables",
                Price = 185.00m
            },
            new Dish
            {
                Name = "Seafood Platter",
                Description = "Prawns, calamari, mussels and line fish",
                Price = 320.00m
            }
        }
    },

    new Restaurant
    {
        Id = 2,
        Name = "Mama's Kitchen",
        Description = "Traditional home-style meals made with love.",
        Category = "Home Food",
        HasDelivery = false,
        ContactEmail = "contact@mamakitchen.co.za",
        ContactNumber = "+27 11 987 6543",
        Address = new Address
        {
            Street = "45 Vilakazi Street",
            City = "Soweto",
            Postalcode = "1804",
        },
        Dishes = new List<Dish>
        {
            new Dish
            {
                Name = "Beef Stew & Pap",
                Description = "Slow-cooked beef stew served with pap",
                Price = 120.00m
            },
            new Dish
            {
                Name = "Grilled Chicken & Rice",
                Description = "Flame-grilled chicken served with savory rice",
                Price = 110.00m
            }
        }
    }
};

        return restaurants;
    }
    
}