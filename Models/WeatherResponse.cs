namespace WeatherMicroservice.Models;

public class WeatherResponse
{
    public string? City { get; set; }
    public double Temperature { get; set; }
    public string? Description { get; set; }
}

public class WeatherApiResponse
{
    public MainData? Main { get; set; }
    public List<WeatherData>? Weather { get; set; }
}

public class MainData
{
    public double Temp { get; set; }
}

public class WeatherData
{
    public string? Description { get; set; }
}
