namespace WeatherBot.Domain.Models
{
    public class WeatherForecast
    {
        public string City { get; set; } = string.Empty;
        public string[] Weather { get; init; } = null!;
        public DateTime Date { get; init; }
        public int Temperture { get; init; }
        public int FeelsLike { get; init; }
        public int Humidity { get; init; }
        /// <summary>
        /// Давление в мм. рт.
        /// </summary>
        public int PressureMmHg { get; init; }        
        public double WindSpeed { get; set; }
        public int WindDegress { get; set; }
        public double WindGust { get; set; }

    }    
}
