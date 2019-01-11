using System;
using WeatherApplication.Services;
using WeatherObjects;
using Xamarin.Forms;

namespace WeatherApplication.Views.SubViews
{
    public partial class ForeCast : ContentView
    {
        public ForeCast()
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
                        (bindable as ForeCast).LblDate.Text = ((DateTime)newValue).ToString("D");
                    }
                });

        public double MinTemp
        {
            get => (double)base.GetValue(MinTempProperty);
            set
            {
                if (MinTemp != value)
                {
                    base.SetValue(MinTempProperty, value);
                }
            }
        }

        public static readonly BindableProperty MinTempProperty = BindableProperty.Create(
                nameof(MinTemp),
                typeof(double),
                typeof(ContentView),
                0.0,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    (bindable as ForeCast).LblMinTemp.Text = ((double)newValue).ToString("0.0") + "°C";
                });

        public double MaxTemp
        {
            get => (double)base.GetValue(MaxTempProperty);
            set
            {
                if (MaxTemp != value)
                {
                    base.SetValue(MaxTempProperty, value);
                }
            }
        }

        public static readonly BindableProperty MaxTempProperty = BindableProperty.Create(
                nameof(MaxTemp),
                typeof(double),
                typeof(ContentView),
                0.0,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    (bindable as ForeCast).LblMaxTemp.Text = ((double)newValue).ToString("0.0") + "°C";
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
                        (bindable as ForeCast).IconWeather.Source = IconSelector.LoadWeatherIcon((Weather)newValue);
                    }
                });
    }
}
