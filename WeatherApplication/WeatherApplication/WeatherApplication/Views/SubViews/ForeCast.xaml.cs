using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WeatherApplication.Views.SubViews
{
    public partial class ForeCast : ContentView
    {
        public ForeCast()
        {
            InitializeComponent();
        }

        public string ForecastDate
        {
            get
            {
                return (string)base.GetValue(ForecastDateProperty);
            }
            set
            {
                if (ForecastDate != value)
                    base.SetValue(ForecastDateProperty, value);
            }
        }
        public static readonly BindableProperty ForecastDateProperty = BindableProperty.Create(
                nameof(ForecastDate),
                typeof(string),
                typeof(ContentView),
                string.Empty,
                propertyChanging: (bindable, oldValue, newValue) =>
                {
                    (bindable as ForeCast).LblDate.Text = newValue.ToString();
                });
    }
}

