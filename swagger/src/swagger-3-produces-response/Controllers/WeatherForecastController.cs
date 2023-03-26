using Microsoft.AspNetCore.Mvc;

namespace swagger_3_produces_response.Controllers;

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
    /// 오늘 ~ 입력한 날짜 하루전에 해당하는 날씨 데이터를 제공합니다.
    /// </summary>
    /// <param name="date" example="2023-02-14T00:00:00">입력날짜</param>
    /// <returns></returns>
    [HttpGet("datetime", Name = "GetWeatherForecastByDateTime")]
    [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), 200)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)] // 그냥 숫자 404로 써도 된다.
    public IActionResult Get([FromQuery] DateTime date) {
        var result = Enumerable.Range(1, 100).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .Where(x => (x.Date - date).TotalDays < 0)
        .ToArray();

        if(result.Length == 0) {
            return NotFound("데이터 없음"); // 데이터가 없을 경우 404 Not Found 로 응답.
        }

        return Ok(result); // 정상적인 데이터를 응답해줄 수 있으므로 200 Ok 로 응답.
    }
}
