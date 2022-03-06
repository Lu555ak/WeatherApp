using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherNowPage : ContentView
    {
        public WeatherNowPage()
        {
            InitializeComponent();
        }

        public string currentTemperature
        {
            get => CurrentTemperature.Text;
            set => CurrentTemperature.Text = value;
        }
        public string currentRealFeel
        {
            get => CurrentRealFeel.Text;
            set => CurrentRealFeel.Text = value;
        }
        public string currentWeather
        {
            get => CurrentWeather.Text;
            set => CurrentWeather.Text = value;
        }

        public string Sunrise
        {
            get => SunriseLabel.Text;
            set => SunriseLabel.Text = value;
        }

        public string Sunset
        {
            get => SunsetLabel.Text;
            set => SunsetLabel.Text = value;
        }

        public string MaxTemperature
        {
            get => MaxTemperatureLabel.Text;
            set => MaxTemperatureLabel.Text = value;
        }

        public string MinTemperature
        {
            get => MinTemperatureLabel.Text;
            set => MinTemperatureLabel.Text = value;
        }

        public string Humidity
        {
            get => HumidityLabel.Text;
            set => HumidityLabel.Text = value;
        }

        public string Pressure
        {
            get => PressureLabel.Text;
            set => PressureLabel.Text = value;
        }
    }
}