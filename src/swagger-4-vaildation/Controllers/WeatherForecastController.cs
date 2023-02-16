using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace swagger_4_vaildation.Controllers;

/// <summary>
/// 날씨 데이터를 제공하는 컨트롤러입니다.
/// </summary>
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 입력된 일수만큼 날씨 데이터를 제공합니다.
    /// </summary>
    /// <param name="cnt" example="7">입력일수</param>
    /// <returns></returns>
    [HttpGet("{cnt}", Name = "GetWeatherForecastByCount")]
    public IEnumerable<WeatherForecast> Get(
        [Required][Range(1, 10, ErrorMessage = "1~10 까지의 값만 사용할 수 있습니다.")] int cnt) {
        return Enumerable.Range(1, cnt).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
