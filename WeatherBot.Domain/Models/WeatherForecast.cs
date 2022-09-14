namespace WeatherBot.Domain.Models
{
    public class WeatherForecast
    {
        public string[] Weather { get; init; } = null!;
        public DateTime Date { get; init; }
        public double Temperture { get; init; }
        public double FeelsLike { get; init; }
        public int Humidity { get; init; }
        /// <summary>
        /// Давление в мм. рт. с.
        /// </summary>
        public int PressureMmHg { get; init; }
        public Wind Wind { get; set; } = null!;

    }

    public class Wind
    {        
        public double Speed { get; set; }        
        public int Degress { get; set; }        
        public double Gust { get; set; }
    }
}
