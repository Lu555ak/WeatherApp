using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherDayPage : ContentPage
    {
        public WeatherDayPage()
        {
            InitializeComponent();
        }

        public ListView weatherDayList { get; set; }
    }
}