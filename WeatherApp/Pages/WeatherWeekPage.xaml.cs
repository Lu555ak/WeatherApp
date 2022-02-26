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
        public WeatherDayWidget this[int i]
        {
            get 
            {
                if (i == 0)
                    return Day1;
                else if (i == 1)
                    return Day2;
                else if (i == 2)
                    return Day3;
                else if (i == 3)
                    return Day4;
                else if (i == 4)
                    return Day5;
                else if (i == 5)
                    return Day6;
                else if (i == 6)
                    return Day7;    
                return Day1;
            }
            set 
            {
                if (i == 0)
                    Day1 = value;
                else if (i == 1)
                    Day2 = value;
                else if (i == 2)
                    Day3 = value;
                else if (i == 3)
                    Day4 = value;
                else if (i == 4)
                    Day5 = value;
                else if (i == 5)
                    Day6 = value;
                else if (i == 6)
                    Day7 = value;
                Day1 = value;
            }
        }

        public WeatherWeekPage()
        {
            InitializeComponent();
        }
    }
}