﻿using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.CustomUI;

namespace WeatherApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherDayPage : ContentView
    {
        public List<WeatherHourWidget> DataSource = new List<WeatherHourWidget>();
        public WeatherDayPage()
        {
            InitializeComponent(); 
            for (int i = 0; i < 24; i++)
                DataSource.Add(new WeatherHourWidget());
            WeatherDayList.ItemsSource = DataSource;
        }
    }
}