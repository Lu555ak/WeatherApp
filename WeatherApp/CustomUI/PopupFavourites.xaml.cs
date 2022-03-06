using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.CustomUI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupFavourites : Frame
    {
        public PopupFavourites()
        {
            InitializeComponent();
        }
    }
}