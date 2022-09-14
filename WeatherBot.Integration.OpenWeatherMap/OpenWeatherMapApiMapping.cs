using AutoMapper;
using WeatherBot.Domain.Models;
using WeatherBot.Integration.OpenWeatherMap.Models;

namespace WeatherBot.Integration.OpenWeatherMap
{
    public class OpenWeatherMapApiMapping : Profile
    {
        public OpenWeatherMapApiMapping()
        {
            CreateMap<WeatherForecastResponse, WeatherForecast>()
                .ForMember(dest => dest.City,
                opt => opt.MapFrom(source => source.Name))
                .ForMember(dest => dest.Weather,
                opt => opt.MapFrom(source => source.Weather.Select(p => p.Description)))
                .ForMember(dest => dest.Date,
                opt => opt.MapFrom(source => source.DateTime))
                .ForMember(dest => dest.Temperture,
                opt => opt.MapFrom(source => source.Response.Temperture))
                .ForMember(dest => dest.FeelsLike,
                opt => opt.MapFrom(source => source.Response.FeelsLike))
                .ForMember(dest => dest.Humidity,
                opt => opt.MapFrom(source => source.Response.Humidity))
                .ForMember(dest => dest.PressureMmHg,
                opt => opt.MapFrom(source => source.Response.PressureMmHg))
                .ForMember(dest => dest.WindSpeed,
                opt => opt.MapFrom(source => source.Wind.Speed))
                .ForMember(dest => dest.WindDegress,
                opt => opt.MapFrom(source => source.Wind.Degress))
                .ForMember(dest => dest.WindGust,
                opt => opt.MapFrom(source => source.Wind.Gust));   
        }
    }
}
