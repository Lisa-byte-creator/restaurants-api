namespace Restaurants.API.Controllers;

// 1. The Interface (separate)
public interface IWeatherForecastService 
{
    IEnumerable<WeatherForecast> Get(int count, int minTemperature, int maxTemperature);
}

// 2. The Class (separate - NOT inside the interface)
public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

//Get()method that takes in 3 params
    public IEnumerable<WeatherForecast> Get(int count, int minTemperature, int maxTemperature)
    {
        //number of results returned
        return Enumerable.Range(1, count).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(minTemperature, maxTemperature),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}