using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace WeatherApp.CustomUI
{
    public partial class NavigationButton : ContentView
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(NavigationButton), propertyChanged: CornerRadiusUpdated);
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(NavigationButton), propertyChanged: SourceUpdated);
        public static readonly BindableProperty BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(Brush), typeof(NavigationButton), propertyChanged: BackgroundUpdated);

        public int CornerRadius
        {
            get => (int)this.GetValue(CornerRadiusProperty);
            set => this.SetValue(CornerRadiusProperty, value);
        }

        public string Source
        {
            get => (string)this.GetValue(SourceProperty);
            set => this.SetValue(SourceProperty, value);
        }

        public Brush Background
        {
            get => (Brush)this.GetValue(BackgroundProperty);
            set => this.SetValue(BackgroundProperty, value);
        }

        private static void CornerRadiusUpdated(object sender, object oldValue, object newValue)
        {
            if (sender is NavigationButton navigationButton && newValue is int newInt)
            {
                navigationButton.BackgroundButton.CornerRadius = newInt;
            }
        }

        private static void SourceUpdated(object sender, object oldValue, object newValue)
        {
            if (sender is NavigationButton navigationButton && newValue is string newString)
            {
                navigationButton.Image.Source = newString;
            }
        }

        private static void BackgroundUpdated(object sender, object oldValue, object newValue)
        {
            if (sender is NavigationButton navigationButton && newValue is Brush newBrush)
            {
                navigationButton.BackgroundButton.Background = newBrush;
            }
        }

        public NavigationButton()
        {
            InitializeComponent();
        }
    }
}