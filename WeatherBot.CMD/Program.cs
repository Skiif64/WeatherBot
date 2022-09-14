using AutoMapper;
using WeatherBot.Integration.OpenWeatherMap;
using WeatherBot.Integration.OpenWeatherMap.Services;

var configuration = new MapperConfiguration(cfg => cfg.AddProfile<OpenWeatherMapApiMapping>());
var mapper = new Mapper(configuration);
var service = new OpenWeatherMapApiClient("28ecf15a565cbafab05b19a00c9a772d", mapper);
var response = service.GetCityWeather("саратов");
Console.ReadLine();
