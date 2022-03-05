using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;

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
            RefreshWeather("buenos aires");
        }

        // Event handlers
        void WeatherNowPageButton_Click(object sender, EventArgs args) => WeatherNowPageActive();
        void WeatherDayPageButton_Click(object sender, EventArgs args) => WeatherDayPageActive();
        void WeatherWeekPageButton_Click(object sender, EventArgs args) => WeatherWeekPageActive();
        void SearchBar_Completed(object sender, EventArgs args) => RefreshWeather(Searchbar.Text);
        void FavouriteButton_Click(object sender, EventArgs args) => FavouriteLocation();

        // Actions
        void WeatherNowPageActive()
        {
            WeatherNowPage.IsVisible = true;
            WeatherDayPage.IsVisible = false;
            WeatherWeekPage.IsVisible = false;
            WeatherNowButton.BorderWidth = 2;
            WeatherDayButton.BorderWidth = 0;
            WeatherWeekButton.BorderWidth = 0;
        }
        void WeatherDayPageActive()
        {
            WeatherNowPage.IsVisible = false;
            WeatherDayPage.IsVisible = true;
            WeatherWeekPage.IsVisible = false;
            WeatherNowButton.BorderWidth = 0;
            WeatherDayButton.BorderWidth = 2;
            WeatherWeekButton.BorderWidth = 0;
        }
        void WeatherWeekPageActive()
        {
            WeatherNowPage.IsVisible = false;
            WeatherDayPage.IsVisible = false;
            WeatherWeekPage.IsVisible = true;
            WeatherNowButton.BorderWidth = 0;
            WeatherDayButton.BorderWidth = 0;
            WeatherWeekButton.BorderWidth = 2;
        }

        void RefreshWeather(string cityName)
        {
            // Refresh WeatherNowPage
            CurrentWeatherInfo.Root weatherInfo = DeserializeData.ReturnCurrentWeatherInfo(cityName);
            WeatherNowPage.currentTemperature = Math.Round(weatherInfo.main.temp).ToString() + "°C";
            WeatherNowPage.currentRealFeel = "RealFeel: " + Math.Round(weatherInfo.main.feels_like).ToString() + "°C";
            WeatherNowPage.currentWeather = weatherInfo.weather[0].main.ToString().ToUpper();

            // Refresh WeatherDayPage
            OneCallWeatherInfo.Root weatherInfo1C = DeserializeData.ReturnOneCallWeatherInfo(weatherInfo.coord.lat, weatherInfo.coord.lon);
            for (int i=0;i<24;i++)
            {
                WeatherDayPage[i].Hour = UnixTimeStampToHour(weatherInfo1C.hourly[i].dt).ToString() + ":00";
                WeatherDayPage[i].Temperature = Math.Round(weatherInfo1C.hourly[i].temp).ToString() + "°C";
                WeatherDayPage[i].WeatherIcon = "https://openweathermap.org/img/wn/" + weatherInfo1C.hourly[i].weather[0].icon.ToString() + "@4x.png";
                WeatherDayPage[i].RealFeel = "≈" + Math.Round(weatherInfo1C.hourly[i].feels_like).ToString() + "°C";
            }
            WeatherDayPage.Refresh();

            // Refresh WeatherWeekPage
            for (int i=0;i<7;i++)
            {
                WeatherWeekPage[i].Day = UnixTimeStampToDay(weatherInfo1C.daily[i].dt).ToString().ToUpper();
                WeatherWeekPage[i].Temperature = Math.Round(weatherInfo1C.daily[i].temp.min).ToString() + "°C/" + Math.Round(weatherInfo1C.daily[i].temp.max).ToString() + "°C";
                WeatherWeekPage[i].WeatherIcon = "https://openweathermap.org/img/wn/" + weatherInfo1C.daily[i].weather[0].icon.ToString() + "@4x.png";
            }
            Date.Text = UnixTimeStampDate(weatherInfo.dt).ToString().Split(' ').First();
        }
        void FavouriteLocation()
        {

        }

        // Utility functions
        int UnixTimeStampToHour(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.Hour;
        }

        DayOfWeek UnixTimeStampToDay(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.DayOfWeek;
        }

        string UnixTimeStampDate(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.Date.ToString();
        }

        async void App_Refresh(object sender, EventArgs args)
        {
            RefreshWeather(Searchbar.Text);
            await Task.Delay(1000);
            RefreshView.IsRefreshing = false;
        }
    }
}
