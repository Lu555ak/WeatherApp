using Xamarin.Forms;

namespace WeatherApp.CustomUI
{
    public partial class WeatherDayWidget : ContentView
    {

        public static readonly BindableProperty DayProperty = BindableProperty.Create(nameof(Day), typeof(string), typeof(WeatherDayWidget), propertyChanged: DayUpdated);
        public static readonly BindableProperty WeatherIconProperty = BindableProperty.Create(nameof(WeatherIcon), typeof(string), typeof(WeatherDayWidget), propertyChanged: WeatherIconUpdated);
        public static readonly BindableProperty TemperatureProperty = BindableProperty.Create(nameof(Temperature), typeof(string), typeof(WeatherDayWidget), propertyChanged: TemperatureUpdated);

        public WeatherDayWidget()
        {
            InitializeComponent();
        }

        public string Day
        {
            get => (string)this.GetValue(DayProperty);
            set => this.SetValue(DayProperty, value);
        }
        public string WeatherIcon
        {
            get => (string)this.GetValue(WeatherIconProperty);
            set => this.SetValue(WeatherIconProperty, value);
        }
        public string Temperature
        {
            get => (string)this.GetValue(TemperatureProperty);
            set => this.SetValue(TemperatureProperty, value);
        }

        private static void DayUpdated(object sender, object oldValue, object newValue)
        {
            if (sender is WeatherDayWidget weatherDayWidget && newValue is string newString)
            {
                weatherDayWidget.DayLabel.Text = newString;
            }
        }

        private static void WeatherIconUpdated(object sender, object oldValue, object newValue)
        {
            if (sender is WeatherDayWidget weatherDayWidget && newValue is string newString)
            {
                weatherDayWidget.WeatherImage.Source = newString;
            }
        }

        private static void TemperatureUpdated(object sender, object oldValue, object newValue)
        {
            if (sender is WeatherDayWidget weatherDayWidget && newValue is string newString)
            {
                weatherDayWidget.TemperatureLabel.Text = newString;
            }
        }
    }
}