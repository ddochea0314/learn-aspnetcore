namespace swagger_1_comments;

/// <summary>
/// 날씨 데이터 모델입니다.
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// 날짜입니다.
    /// </summary>
    /// <value></value>
    /// <example>2021-08-01T00:00:00</example>
    public DateTime Date { get; set; }
    /// <summary>
    /// 섭씨온도입니다.
    /// </summary>
    /// <value></value>
    /// <example>42</example>
    public int TemperatureC { get; set; }
    /// <summary>
    /// 화씨온도입니다.
    /// </summary>
    /// <returns></returns>
    /// <example>107</example>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    /// <summary>
    /// 날씨 내용입니다.
    /// </summary>
    /// <value></value>
    /// <example>Freezing</example>
    public string? Summary { get; set; }
}
