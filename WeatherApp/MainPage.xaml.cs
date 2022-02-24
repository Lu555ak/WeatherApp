using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;  
using Xamarin.Forms;
using WeatherApp.Pages;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        WeatherNowPage weatherNow = new WeatherNowPage();
        WeatherDayPage weatherDay = new WeatherDayPage();
        WeatherWeekPage WeatherWeek = new WeatherWeekPage();

        const string appid = "3b7c3947e8e22c86b32d822ad4c3a6b6";
        public MainPage()
        {
            InitializeComponent();
            

            CurrentPage.Content = weatherNow.Content;
        }

        void GetCurrentWeather(string cityName)
        {
            using (WebClient web = new WebClient())
            {
                string url = String.Format("https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&units=metric&appid=" + appid);
                var json = web.DownloadString(url);
                var result = JsonConvert.DeserializeObject<CurrentWeatherInfo.root>(json);
                CurrentWeatherInfo.root outPut = result;

                
                weatherNow.currentTemperature = Convert.ToString(outPut.main.temp);
                weatherNow.currentRealFeel = Convert.ToString(outPut.main.feels_like);
                weatherNow.currentWeather = Convert.ToString(outPut.weatherList[1]);
            }        
        }

        void WeatherNowPageButton_Click(object sender, EventArgs args)
        {
            CurrentPage.Content = weatherNow.Content;
        }
        
        void WeatherDayPageButton_Click(object sender, EventArgs args)
        {
            CurrentPage.Content = weatherDay.Content;
        }
        
        void WeatherWeekPageButton_Click(object sender, EventArgs args)
        {
            CurrentPage.Content = WeatherWeek.Content;
        }

        void SearchBar_Completed(object sender, EventArgs args)
        {
            GetCurrentWeather("Samobor");
        }
    }
}
