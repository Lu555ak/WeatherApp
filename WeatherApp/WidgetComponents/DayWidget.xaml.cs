﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.WidgetComponents
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DayWidget : ContentView
    {
        public DayWidget()
        {
            InitializeComponent();
        }
    }
}