using Microsoft.AspNetCore.Mvc;

namespace swagger_5_enum.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 날씨 데이터를 제공합니다.
    /// </summary>
    /// <returns></returns>

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Enum.Parse<WeatherSummary>(Summaries[Random.Shared.Next(Summaries.Length)])
        })
        .ToArray();
    }

    /// <summary>
    /// 입력받은 날씨 요약으로 날씨 데이터를 제공합니다.
    /// </summary>
    /// <param name="summary"></param>
    /// <returns></returns>
    [HttpGet("WeatherSummary", Name = "GetWeatherForecastBySummary")]
    public IEnumerable<WeatherForecast> Get([FromQuery] WeatherSummary summary)
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summary
        })
        .ToArray();
    }
}
