using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        string URL;
        const string appid = "";
        string cityName = "Samobor";
        public MainPage()
        {
            InitializeComponent();
            GetCurrentWeather();
        }

        void GetCurrentWeather()
        {
            URL = "https://api.openweathermap.org/data/2.5/weather?q=Samobor&appid=3b7c3947e8e22c86b32d822ad4c3a6b6";
            using (WebClient web = new WebClient())
            { 
                var json = web.DownloadString(URL);
            }        
        }
    }
}
