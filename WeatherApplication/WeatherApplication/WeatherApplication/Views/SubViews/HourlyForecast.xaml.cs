using System;
using System.Collections.Generic;
using WeatherApplication.Services;
using WeatherObjects.Enums;
using Xamarin.Forms;

namespace WeatherApplication.Views.SubViews
{
    public partial class HourlyForecast : ContentView
    {
        public HourlyForecast()
        {
            InitializeComponent();
        }


        public string ForecastTime
        {
            get => (string)base.GetValue(ForecastTimeProperty);
            set
            {
                if (ForecastTime != value)
                    base.SetValue(ForecastTimeProperty, value);
            }
        }
        public static readonly BindableProperty ForecastTimeProperty = BindableProperty.Create(
                nameof(ForecastTime),
                typeof(string),
                typeof(ContentView),
                string.Empty,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    (bindable as HourlyForecast).LblTime.Text = newValue.ToString();
                });

        public string ForecastTemp
        {
            get => (string)base.GetValue(ForecastTempProperty);
            set
            {
                if (ForecastTemp != value)
                    base.SetValue(ForecastTempProperty, value);
            }
        }
        public static readonly BindableProperty ForecastTempProperty = BindableProperty.Create(
                nameof(ForecastTemp),
                typeof(string),
                typeof(ContentView),
                string.Empty,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    (bindable as HourlyForecast).LblTemp.Text = newValue.ToString();
                });

        public Weather ForecastWeather
        {
            get => (Weather)base.GetValue(ForecastWeatherProperty);
            set
            {
                if (ForecastWeather != value)
                    base.SetValue(ForecastWeatherProperty, value);
            }
        }
        public static readonly BindableProperty ForecastWeatherProperty = BindableProperty.Create(
                nameof(ForecastWeather),
                typeof(Weather),
                typeof(ContentView),
                string.Empty,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    (bindable as HourlyForecast).ImgWeather.Source = IconSelector.LoadWeatherIcon((Weather)newValue);                });
    }


}
