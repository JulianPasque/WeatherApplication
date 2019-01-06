using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WeatherApplication.Views
{
    public partial class AdressBasedWeather : ContentPage
    {
        public AdressBasedWeather()
        {
            InitializeComponent();
        }

        void Expand(object sender, Xamarin.Forms.SwipedEventArgs e)
        {
            Action<double> callback = input => ((Frame)sender).HeightRequest = input;
            ((Frame)sender).Animate("expand", callback, 15, 175, 5, 500, Easing.CubicIn);


        }
        void Collapse(object sender, Xamarin.Forms.SwipedEventArgs e)
        {
            Action<double> callback = input => ((Frame)sender).HeightRequest = input;
            ((Frame)sender).Animate("expand", callback, 175, 15, 5, 500, Easing.CubicOut);


        }

    }
}
