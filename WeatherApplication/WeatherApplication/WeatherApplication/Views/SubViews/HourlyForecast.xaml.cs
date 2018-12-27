using System;
using System.Collections.Generic;
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
            get
            {
                return (string)base.GetValue(ForecasttTimeProperty);
            }
            set
            {
                if (ForecastTime != value)
                    base.SetValue(ForecasttTimeProperty, value);
            }
        }
        public static readonly BindableProperty ForecasttTimeProperty = BindableProperty.Create(
                nameof(ForecastTime),
                typeof(string),
                typeof(ContentView),
                string.Empty,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    (bindable as HourlyForecast).LblTime.Text = newValue.ToString();
                });
    }


}
