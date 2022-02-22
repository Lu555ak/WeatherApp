using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;  
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        const string appid = "3b7c3947e8e22c86b32d822ad4c3a6b6";
        string cityName = "Samobor";
        public MainPage()
        {
            InitializeComponent();
            GetCurrentWeather(cityName);
        }

        void GetCurrentWeather(string cityName)
        {
            using (WebClient web = new WebClient())
            {
                string url = String.Format("https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=" + appid);
                var json = web.DownloadString(url);
                var result = JsonConvert.DeserializeObject<CurrentWeatherInfo.root>(json);
                CurrentWeatherInfo.root outPut = result;
            }        
        }
    }
}
