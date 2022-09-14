using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherBot.Integration.OpenWeatherMap.Converters
{
    public class UnixDateTimeConverter : JsonConverter<DateTime>
    {
        public UnixDateTimeConverter()
        {

        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TryGetInt32(out var number))
            {
                var dateTime = DateTimeOffset.FromUnixTimeSeconds(number).DateTime;
                return dateTime;
            }
            return default;

        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}