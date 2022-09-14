using WeatherBot.Integration.OpenWeatherMap.Services;

var service = new OpenWeatherMapApiClient("28ecf15a565cbafab05b19a00c9a772d");
var response = service.GetCityWeather("саратов");
Console.ReadLine();
