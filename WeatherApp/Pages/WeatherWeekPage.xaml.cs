using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.CustomUI;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherWeekPage : ContentView
    {
        public List<WeatherDayWidget> DataSource = new List<WeatherDayWidget>();
        public WeatherWeekPage()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
                DataSource.Add(new WeatherDayWidget());
        }

        public void Refresh()
        {
            Day1.Day = DataSource[0].Day;
            Day1.Temperature = DataSource[0].Temperature;
            Day1.WeatherIcon = DataSource[0].WeatherIcon;

            Day2.Day = DataSource[1].Day;
            Day2.Temperature = DataSource[1].Temperature;
            Day2.WeatherIcon = DataSource[1].WeatherIcon;

            Day3.Day = DataSource[2].Day;
            Day3.Temperature = DataSource[2].Temperature;
            Day3.WeatherIcon = DataSource[2].WeatherIcon;

            Day4.Day = DataSource[3].Day;
            Day4.Temperature = DataSource[3].Temperature;
            Day4.WeatherIcon = DataSource[3].WeatherIcon;

            Day5.Day = DataSource[4].Day;
            Day5.Temperature = DataSource[4].Temperature;
            Day5.WeatherIcon = DataSource[4].WeatherIcon;

            Day6.Day = DataSource[5].Day;
            Day6.Temperature = DataSource[5].Temperature;
            Day6.WeatherIcon = DataSource[5].WeatherIcon;

            Day7.Day = DataSource[6].Day;
            Day7.Temperature = DataSource[6].Temperature;
            Day7.WeatherIcon = DataSource[6].WeatherIcon;
        }
    }
}