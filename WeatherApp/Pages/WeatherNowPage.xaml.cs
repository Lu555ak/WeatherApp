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
    }
}