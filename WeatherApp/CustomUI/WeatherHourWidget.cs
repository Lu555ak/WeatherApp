namespace WeatherApp.CustomUI
{
    public class WeatherHourWidget
    {
        public WeatherHourWidget(string hour, string weatherIcon, string temperature, string realFeel)
        {
            Hour = hour;
            WeatherIcon = weatherIcon;
            Temperature = temperature;
            RealFeel = realFeel;
        }
        public WeatherHourWidget() {}

        public string Hour { get; set; }
        public string WeatherIcon { get; set; }
        public string Temperature { get; set; }
        public string RealFeel { get; set; }
    }
}
