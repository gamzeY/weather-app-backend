# Weather Microservice

A .NET 8-based microservice that fetches real-time weather data for a city using OpenWeatherMap API.

## Features

- Get current weather data by city name.
- Input validation with FluentValidation.
- Unit testing with xUnit, Moq, and FluentAssertions.
- CORS enabled for frontend-backend communication.
- Scalable architecture with clear separation of concerns.

## Technologies Used

- **.NET 8**: Framework for building the API.
- **FluentValidation**: Input validation.
- **xUnit, Moq, FluentAssertions**: Testing tools.
- **ASP.NET Core**: For the RESTful API.
- **OpenWeatherMap API**: Weather data provider.

## Prerequisites

- **.NET 8 SDK**: [Download here](https://dotnet.microsoft.com/download)
- **Visual Studio/VS Code**
- **Postman or a web client**
- **OpenWeatherMap API Key**: [Sign up here](https://openweathermap.org/)

## Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/weather-microservice.git
   cd weather-microservice
2. Open the solution file WeatherMicroservice.sln in Visual Studio or VS Code
3. Add your OpenWeatherMap API Key in appsettings.json:
   ```bash
   {
     "ApiKey": "YOUR_API_KEY",
      "EndpointBaseUrl": "https://api.openweathermap.org/data/2.5/weather"
   }
4. API Endpoints
GET /api/Weather/{city}: Fetch weather data for a city. Example response:
   ```bash
   {
     "city": "London",
     "temperature": 16.5,
     "description": "light rain"
   }
5. Testing
   Run all tests with:
   ```bash
   dotnet test

## License
This project is licensed under the MIT License.
