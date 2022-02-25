using System;
using Xamarin.Forms;
using WeatherApp.Pages;
using WeatherApp.Data;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        WeatherNowPage weatherNow = new WeatherNowPage();
        WeatherDayPage weatherDay = new WeatherDayPage();
        WeatherWeekPage WeatherWeek = new WeatherWeekPage();

        public MainPage()
        {
            InitializeComponent();

            CurrentPage.Content = weatherNow.Content;
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
            RefreshWeather(Searchbar.Text);
        }

        void RefreshWeather(string cityName)
        {
            CurrentWeatherInfo.Root weatherInfo = DeserializeData.ReturnCurrentWeatherInfo(cityName);
            weatherNow.currentTemperature = Math.Round(weatherInfo.main.temp).ToString() + "°C";
            weatherNow.currentRealFeel = "RealFeel: " + Math.Round(weatherInfo.main.feels_like).ToString() + "°C";
            weatherNow.currentWeather = weatherInfo.weather[0].main.ToString().ToUpper();
        }
    }
}
