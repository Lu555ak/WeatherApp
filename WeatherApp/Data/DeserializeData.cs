using System.Net;
using Newtonsoft.Json;

namespace WeatherApp.Data
{
    public static class DeserializeData
    {
        const string appid = "3b7c3947e8e22c86b32d822ad4c3a6b6";

        private static T DownloadSeralizedData<T>(string cityName)
        {
            string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&units=metric&appid=" + appid);
            using (WebClient wc = new WebClient())
            {
                var json = string.Empty;
                json = wc.DownloadString(url);
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public static CurrentWeatherInfo.Root ReturnCurrentWeatherInfo(string cityName)
        {
            return DownloadSeralizedData<CurrentWeatherInfo.Root>(cityName);
        }
    }
}
