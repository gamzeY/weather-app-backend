using Newtonsoft.Json;
using WeatherMicroservice.Models;

namespace WeatherMicroservice.Services;

public class WeatherService : IWeatherService
{
    private readonly string _apiKey;
    private readonly string _endpointBaseUrl;
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["WeatherApi:ApiKey"] ?? throw new ArgumentNullException("API key is missing in configuration.");
        _endpointBaseUrl = configuration["WeatherApi:EndpointBaseUrl"] ?? throw new ArgumentNullException("Weather Endpoint URL is missing in configuration.");
    }
    public async Task<WeatherResponse> GetWeatherAsync(string city)
    {
        var builder = new UriBuilder(_endpointBaseUrl)
        {
            Query = $"q={city}&apikey={_apiKey}&units=metric"
        };

        var url = builder.ToString();

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"API Error: {errorContent}");
        }

        var content = await response.Content.ReadAsStringAsync();
        var weatherData = JsonConvert.DeserializeObject<WeatherApiResponse>(content);
        
        if (weatherData == null || weatherData.Main == null || weatherData.Weather == null)
        {
            throw new Exception("Invalid API response structure.");
        }

        return new WeatherResponse
        {
            City = city,
            Temperature = weatherData?.Main?.Temp ?? 0,
            Description = weatherData?.Weather?.FirstOrDefault()?.Description ?? "No description"
        };
    }
}
