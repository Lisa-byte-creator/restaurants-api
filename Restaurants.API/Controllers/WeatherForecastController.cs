using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

public class TemperatreRequest
{
    public int min {get; set;}
    public int max {get; set;}
}
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
   

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

 public WeatherForecastController(ILogger<WeatherForecastController> logger, 
    IWeatherForecastService weatherForecastService) 
{
    _logger = logger;
    _weatherForecastService = weatherForecastService;
}
[HttpPost("generate")]

//2 data model sent by the client
public IActionResult Generate([FromQuery]int count, [FromBody] TemperatreRequest request )
    {
        //checking validation
        if(count < 0 || request.max < request.min)
        {
            return BadRequest("count has to be positive number and max must be greater than the min value");
        }
        var result = _weatherForecastService.Get(count, request.max, request.min);

        return Ok(result);
    }
}
