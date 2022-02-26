using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.CustomUI;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherDayPage : ContentView
    {
        public WeatherHourWidget this[int i]
        {
            get => DataSource[i];
            set => DataSource[i] = value;
        }

        private List<WeatherHourWidget> DataSource = new List<WeatherHourWidget>();
        public WeatherDayPage()
        {
            InitializeComponent(); 
            for (int i = 0; i < 24; i++)
                DataSource.Add(new WeatherHourWidget());
        }

        public void Refresh()
        {
            WeatherDayList.ItemsSource = null;
            WeatherDayList.ItemsSource = DataSource;
        }
    }
}