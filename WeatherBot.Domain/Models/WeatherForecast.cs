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
        /// Давление в мм. рт.
        /// </summary>
        public int PressureMmHg { get; init; }        
        public double WindSpeed { get; set; }
        public int WindDegress { get; set; }
        public double WindGust { get; set; }

    }    
}
