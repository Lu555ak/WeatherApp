using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Linq;

using WeatherApp.Pages;
using WeatherApp.Data;
using System.IO;
using System.Collections.Generic;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        int favouriteIndex = 0;
        List<string> favouriteLocations = new List<string>();
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "lastlocation.txt");
        string _fileFavourteLocations= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "favouritelocations.txt");
        public MainPage()
        {
            InitializeComponent();
            WeatherNowPageActive();
            LoadFavourites();
            LoadLastLocation();
            FavouritesButton_Subscribe();
        }


        // Event handlers
        void WeatherNowPageButton_Click(object sender, EventArgs args) => WeatherNowPageActive();
        void WeatherDayPageButton_Click(object sender, EventArgs args) => WeatherDayPageActive();
        void WeatherWeekPageButton_Click(object sender, EventArgs args) => WeatherWeekPageActive();
        void SearchBar_Completed(object sender, EventArgs args) => RefreshWeather(Searchbar.Text);
        void FavouriteButton_Click(object sender, EventArgs args) => FavouriteLocation();
        void MenuButton_Click(object sender, EventArgs args) => FavouriteLocationMenu();
        
        void FavouritesButton_Subscribe()
        {
            FavouritesPopup[0].Clicked += delegate (object sender, EventArgs e)
            {
                if(FavouritesPopup[0].Text != "<EMPTY>")
                {
                    RefreshWeather(FavouritesPopup[0].Text);
                    Searchbar.Text = FavouritesPopup[0].Text;
                    FavouriteButton.Source = "FavouriteIcon_Selected.png";
                    FavouritesPopup.IsVisible = false;
                }      
            };
            FavouritesPopup[1].Clicked += delegate (object sender, EventArgs e)
            {
                if (FavouritesPopup[1].Text != "<EMPTY>")
                {
                    RefreshWeather(FavouritesPopup[1].Text);
                    Searchbar.Text = FavouritesPopup[1].Text;
                    FavouriteButton.Source = "FavouriteIcon_Selected.png";
                    FavouritesPopup.IsVisible = false;
                }
            };
            FavouritesPopup[2].Clicked += delegate (object sender, EventArgs e)
            {
                if (FavouritesPopup[2].Text != "<EMPTY>")
                {
                    RefreshWeather(FavouritesPopup[2].Text);
                    Searchbar.Text = FavouritesPopup[2].Text;
                    FavouriteButton.Source = "FavouriteIcon_Selected.png";
                    FavouritesPopup.IsVisible = false;
                }
            };
        }

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
            Searchbar.Text = Searchbar.Text.ToUpper();
            // Refresh WeatherNowPage
            CurrentWeatherInfo.Root weatherInfo = DeserializeData.ReturnCurrentWeatherInfo(cityName);
            Date.Text = UnixTimeStampDate(weatherInfo.dt).ToString().Split(' ').First();
            WeatherNowPage.currentTemperature = Math.Round(weatherInfo.main.temp).ToString() + "°C";
            WeatherNowPage.currentRealFeel = "RealFeel: " + Math.Round(weatherInfo.main.feels_like).ToString() + "°C";
            WeatherNowPage.currentWeather = weatherInfo.weather[0].main.ToString().ToUpper();
            WeatherNowPage.Pressure = weatherInfo.main.pressure.ToString() + "hPa";
            WeatherNowPage.Humidity = weatherInfo.main.humidity.ToString() + "%";
            WeatherNowPage.MinTemperature = Math.Round(weatherInfo.main.temp_min).ToString() + "°C";
            WeatherNowPage.MaxTemperature = Math.Round(weatherInfo.main.temp_max).ToString() + "°C";
            WeatherNowPage.Sunset = UnixTimeStampToHour(weatherInfo.sys.sunset).ToString() + ":" + UnixTimeStampToMin(weatherInfo.sys.sunset).ToString();
            WeatherNowPage.Sunrise = UnixTimeStampToHour(weatherInfo.sys.sunrise).ToString() + ":" + UnixTimeStampToMin(weatherInfo.sys.sunrise).ToString();

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

            // Save to File
            File.WriteAllText(_fileName, cityName);
            FavouriteButton.Source = "FavouriteIcon_Unselected.png";
            for (int i = 0; i < favouriteIndex; i++)
            {
                if (favouriteLocations[i] == Searchbar.Text)
                {
                    FavouriteButton.Source = "FavouriteIcon_Selected.png";
                }
            } 
        }
        void FavouriteLocation()
        {
            if(Searchbar.Text != "<EMPTY>")
            {
                if (FavouriteButton.Source.ToString() == "File: FavouriteIcon_Unselected.png")
                {
                    File.Create(_fileFavourteLocations).Close();
                    FavouriteButton.Source = "FavouriteIcon_Selected.png";
                    favouriteLocations.Add(Searchbar.Text);
                    TextWriter tw = new StreamWriter(_fileFavourteLocations);
                    foreach (String s in favouriteLocations)
                        tw.WriteLine(s);
                    tw.Close();
                    favouriteIndex++;
                }
                else
                {
                    FavouriteButton.Source = "FavouriteIcon_Unselected.png";
                    File.Create(_fileFavourteLocations).Close();
                    for (int i = 0; i < favouriteIndex; i++)
                    {
                        if (favouriteLocations[i] == Searchbar.Text)
                        {
                            favouriteLocations.Remove(Searchbar.Text);
                            favouriteIndex--;
                        }
                        TextWriter tw = new StreamWriter(_fileFavourteLocations);
                        foreach (String s in favouriteLocations)
                            tw.WriteLine(s);
                        tw.Close();
                    }
                }
                LoadFavouritesToMenu();
            }        
        }

        void FavouriteLocationMenu()
        {
            FavouritesPopup.IsVisible = !FavouritesPopup.IsVisible;
            FavouritesPopup.Margin = new Thickness(App.ScreenWidth/3.33333333333333, 0, 0, 0);
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

        int UnixTimeStampToMin(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime.Minute;
        }

        async void App_Refresh(object sender, EventArgs args)
        {
            RefreshWeather(Searchbar.Text);
            await Task.Delay(1000);
            RefreshView.IsRefreshing = false;
        }

        void LoadLastLocation()
        {
            if (File.Exists(_fileName))
            {
                Searchbar.Text = File.ReadAllText(_fileName);
                RefreshWeather(File.ReadAllText(_fileName));
            }
            else
            {
                Searchbar.Text = "SAMOBOR";
                RefreshWeather("Samobor");
            }
        }

        void LoadFavourites()
        {
            if (File.Exists(_fileFavourteLocations))
            {
                favouriteLocations = File.ReadAllLines(_fileFavourteLocations).ToList();
                foreach (string s in favouriteLocations)
                    favouriteIndex++;
            }
            LoadFavouritesToMenu();
        }

        void LoadFavouritesToMenu()
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    FavouritesPopup[i].Text = favouriteLocations[i];
                }
                catch
                {
                    FavouritesPopup[i].Text = "<EMPTY>";
                }
            }
            if (favouriteIndex > 3)
            {
                FavouritesPopup.MoreText = "+" + (favouriteIndex - 3).ToString() + " more";
                FavouritesPopup.Visibility = true;
            }           
            else
                FavouritesPopup.Visibility = false;
        }
    }
}
