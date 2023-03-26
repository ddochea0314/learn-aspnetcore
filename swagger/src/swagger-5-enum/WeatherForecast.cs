namespace swagger_5_enum;

/// <summary>
/// 날씨 요약
/// </summary>
public enum WeatherSummary
{
    /// <summary>
    /// 얼어붙다
    /// </summary>
    Freezing,

    /// <summary>
    /// 상쾌하다
    /// </summary>
    Bracing,

    /// <summary>
    /// 쌀쌀하다
    /// </summary>
    Chilly,

    /// <summary>
    /// 시원하다
    /// </summary>
    Cool,

    /// <summary>
    /// 온화하다
    /// </summary>
    Mild,

    /// <summary>
    /// 따뜻하다
    /// </summary>
    Warm,

    /// <summary>
    /// 따뜻하고 상쾌한
    /// </summary>
    Balmy,

    /// <summary>
    /// 더운 
    /// </summary>
    Hot,

    /// <summary>
    /// 찜통 같은
    /// </summary>
    Sweltering,

    /// <summary>
    /// 타는 듯한
    /// </summary>
    Scorching
}


public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public WeatherSummary? Summary { get; set; }
}
