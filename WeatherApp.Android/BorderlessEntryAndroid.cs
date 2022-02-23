using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WeatherApp.CustomUI;
using WeatherApp.Droid;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryAndroid))]
namespace WeatherApp.Droid
{
    public class BorderlessEntryAndroid : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}