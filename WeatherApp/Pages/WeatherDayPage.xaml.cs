using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.CustomUI;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherDayPage : ContentPage
    {
        public WeatherDayPage()
        {
            InitializeComponent();

            string test = "https://www.iconsdb.com/icons/preview/white/partly-cloudy-day-xxl.png";
            List<WeatherHourWidget> widgets = new List<WeatherHourWidget>
            {
                new WeatherHourWidget("5:00h", test, "7°C"),
                new WeatherHourWidget("6:00h", test, "8°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
                new WeatherHourWidget("7:00h", test, "7°C"),
            };
            WeatherDayList.ItemsSource = widgets;
        }
    }
}