using Microsoft.AspNetCore.Mvc;
using swagger_2_explain_examples.Dtos;

namespace swagger_2_explain_examples.Controllers;

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
    /// 날씨 데이터를 제공하는 컨트롤러입니다.
    /// </summary>
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    /// <summary>
    /// 입력된 일수만큼 날씨 데이터를 제공합니다.
    /// </summary>
    /// <param name="cnt" example="7">입력일수</param>
    /// <returns></returns>
    [HttpGet("{cnt}", Name = "GetWeatherForecastByCount")]
    public IEnumerable<WeatherForecast> Get(int cnt) {
        return Enumerable.Range(1, cnt).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
    
    /// <summary>
    /// 입력한 요약에 해당하는 날씨 데이터를 제공합니다.
    /// </summary>
    /// <param name="summary" example="Freezing">입력한 날씨요약</param>
    /// <returns></returns>
    [HttpGet("summary", Name = "GetWeatherForecastBySummary")]
    public IEnumerable<WeatherForecast> Get([FromQuery] string summary) {
        return Enumerable.Range(1, 100).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .Where(x => summary == x.Summary)
        .ToArray();
    }

    /// <summary>
    /// 오늘 ~ 입력한 날짜 하루전에 해당하는 날씨 데이터를 제공합니다.
    /// </summary>
    /// <param name="date" example="2023-02-14T00:00:00">입력날짜</param>
    /// <returns></returns>
    [HttpGet("datetime", Name = "GetWeatherForecastByDateTime")]
    public IEnumerable<WeatherForecast> Get([FromQuery] DateTime date) {
        return Enumerable.Range(1, 100).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .Where(x => (x.Date - date).TotalDays < 0)
        .ToArray();
    }

    /// <summary>
    /// 짝수날만 가져올지, 아니면 홀수날만 가져올지 필터링하여 날씨 데이터를 제공합니다.
    /// </summary>
    /// <param name="isEven" example="false">짝수여부</param>
    /// <returns></returns>
    [HttpGet("bool", Name = "GetWeatherForecastByBool")]
    public IEnumerable<WeatherForecast> Get([FromQuery] bool isEven) {
        return Enumerable.Range(1, 100).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .Where(x => x.Date.Day % 2 == (isEven ? 0 : 1))
        .ToArray();
    }

    /// <summary>
    /// 입력한 DTO객체 요청에 해당하는 날씨 데이터를 제공합니다.
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [HttpGet("request", Name = "GetWeatherForecastByRequest")]
    public IEnumerable<WeatherForecast> Get([FromQuery] WeatherForecastRequest req) {
        return Enumerable.Range(1, req.Cnt).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .Where(x => req.Summaries!.Contains(x.Summary))
        .ToArray();
    }
}
