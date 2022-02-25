using System;
using Xamarin.Forms;
using WeatherApp.Pages;
using WeatherApp.Data;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            WeatherNowPageActive();
        }

        // Event handlers
        void WeatherNowPageButton_Click(object sender, EventArgs args) => WeatherNowPageActive();
        void WeatherDayPageButton_Click(object sender, EventArgs args) => WeatherDayPageActive();
        void WeatherWeekPageButton_Click(object sender, EventArgs args) => WeatherWeekPageActive();
        void SearchBar_Completed(object sender, EventArgs args) => RefreshWeather(Searchbar.Text);

        // Actions
        void WeatherNowPageActive()
        {
            WeatherNowPage.IsVisible = true;
            WeatherDayPage.IsVisible = false;
            WeatherWeekPage.IsVisible = false;
        }
        void WeatherDayPageActive()
        {
            WeatherNowPage.IsVisible = false;
            WeatherDayPage.IsVisible = true;
            WeatherWeekPage.IsVisible = false;
        }
        void WeatherWeekPageActive()
        {
            WeatherNowPage.IsVisible = false;
            WeatherDayPage.IsVisible = false;
            WeatherWeekPage.IsVisible = true;
        }

        void RefreshWeather(string cityName)
        {
            // Refresh WeatherNowPage
            CurrentWeatherInfo.Root weatherInfo = DeserializeData.ReturnCurrentWeatherInfo(cityName);
            WeatherNowPage.currentTemperature = Math.Round(weatherInfo.main.temp).ToString() + "°C";
            WeatherNowPage.currentRealFeel = "RealFeel: " + Math.Round(weatherInfo.main.feels_like).ToString() + "°C";
            WeatherNowPage.currentWeather = weatherInfo.weather[0].main.ToString().ToUpper();

            // Refresh WeatherDayPage

            // Refresh WeatherWeekPage
        }
    }
}
