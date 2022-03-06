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
            string defaulturl = string.Format("https://api.openweathermap.org/data/2.5/weather?q=Samobor&units=metric&appid=" + appid);
            using (WebClient wc = new WebClient())
            {
                var json = string.Empty;
                try
                {
                    json = wc.DownloadString(url);
                }      
                catch
                {
                    json = wc.DownloadString(defaulturl);
                }
                return JsonConvert.DeserializeObject<T>(json);
            }
        }


        private static T DownloadSeralized1CData<T>(string lat, string lon)
        {
            string url1C = string.Format("https://api.openweathermap.org/data/2.5/onecall?lat=" + lat + "&lon=" + lon + "&exclude=minutely,current&units=metric&appid=" + appid);
            using (WebClient wc1C = new WebClient())
            {
                var json1C = string.Empty;
                json1C = wc1C.DownloadString(url1C);
                return JsonConvert.DeserializeObject<T>(json1C);
            }
        }

        public static CurrentWeatherInfo.Root ReturnCurrentWeatherInfo(string cityName)
        {
            return DownloadSeralizedData<CurrentWeatherInfo.Root>(cityName);
        }

        public static OneCallWeatherInfo.Root ReturnOneCallWeatherInfo(double lat, double lon)
        {
            return DownloadSeralized1CData<OneCallWeatherInfo.Root>(lat.ToString(), lon.ToString());
        }
    }
}
