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
    public partial class FavouritePopup : Frame
    {
        public string MoreText
        {
            get => moreLabel.Text;
            set => moreLabel.Text = value;
        }

        public bool Visibility
        {
            get => moreLabel.IsVisible;
            set => moreLabel.IsVisible = value;
        }

        public Button this[int i]
        {
            get
            {
                if (i == 0)
                    return F1;
                else if (i == 1)
                    return F2;
                else if (i == 2)
                    return F3;
                else
                    return null;
            }
            set
            {
                if (i == 0)
                    F1 = value;
                else if (i == 1)
                    F2 = value;
                else if (i == 2)
                    F3 = value;
            }
        }

        public FavouritePopup()
        {
            InitializeComponent();
        }
 
    }
}