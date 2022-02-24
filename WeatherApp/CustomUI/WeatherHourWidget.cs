namespace WeatherApp.CustomUI
{
    public class WeatherHourWidget
    {
        public WeatherHourWidget(string hour, string weatherIcon, string temperature)
        {
            Hour = hour;
            WeatherIcon = weatherIcon;
            Temperature = temperature;
        }

        public string Hour { get; set; }
        public string WeatherIcon { get; set; }
        public string Temperature { get; set; }
    }
}
