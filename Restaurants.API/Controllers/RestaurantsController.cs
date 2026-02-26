using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurants")]

public class RestaurantsController(IRestaurantsService restaurantsService) : ControllerBase{

    //fetch resorces from the Server
    [HttpGet]
    public async Task<IActionResult> GetAll(){

        //get all the restaurants and return them in an ok method 
        var restaurants = await restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetbyId([FromRoute]int id){

        var restaurant = await restaurantsService.GetbyId(id);

        if (restaurant is null ){

            return notFound();

            return Ok(restaurant);
        }

    }
}