using System;
using WeatherApplication.Services;
using WeatherObjects;
using Xamarin.Forms;

namespace WeatherApplication.Views.SubViews
{
    public partial class HourlyForecast : ContentView
    {
        public HourlyForecast()
        {
            InitializeComponent();
        }

        public DateTime ForecastTime
        {
            get => (DateTime)base.GetValue(ForecastTimeProperty);
            set
            {
                if (ForecastTime != value)
                {
                    base.SetValue(ForecastTimeProperty, value);
                }
            }
        }

        public static readonly BindableProperty ForecastTimeProperty = BindableProperty.Create(
                nameof(ForecastTime),
                typeof(DateTime),
                typeof(ContentView),
                null,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    if (newValue != null)
                    {
                        (bindable as HourlyForecast).LblTime.Text = ((DateTime)newValue).ToString("t");
                    }
                });

        public double ForecastTemp
        {
            get => (double)base.GetValue(ForecastTempProperty);
            set
            {
                if (ForecastTemp != value)
                {
                    base.SetValue(ForecastTempProperty, value);
                }
            }
        }

        public static readonly BindableProperty ForecastTempProperty = BindableProperty.Create(
                nameof(ForecastTemp),
                typeof(double),
                typeof(ContentView),
                0.0,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    (bindable as HourlyForecast).LblTemp.Text = ((double)newValue).ToString("0.0") + "°C";
                });

        public Weather ForecastWeather
        {
            get => (Weather)base.GetValue(ForecastWeatherProperty);
            set
            {
                if (ForecastWeather != value)
                {
                    base.SetValue(ForecastWeatherProperty, value);
                }
            }
        }

        public static readonly BindableProperty ForecastWeatherProperty = BindableProperty.Create(
                nameof(ForecastWeather),
                typeof(Weather),
                typeof(ContentView),
                null,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    if (newValue != null)
                    {
                        (bindable as HourlyForecast).ImgWeather.Source = IconSelector.LoadWeatherIcon((Weather)newValue);
                    }
                });
    }
}
