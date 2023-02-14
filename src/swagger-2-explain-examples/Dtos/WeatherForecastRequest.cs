namespace swagger_2_explain_examples.Dtos;
/// <summary>
/// 날씨 조회 Request Dto모델 입니다.
/// </summary>
public class WeatherForecastRequest
{
    /// <summary>
    /// 입력일수
    /// </summary>
    /// <example>7</example>
    public int Cnt { get; set; }
    
    /// <summary>
    /// 입력한 날씨요약
    /// </summary>
    /// <example>["Freezing", "Cold"]</example>
    public string[]? Summaries { get; set; }
}