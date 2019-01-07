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
            ((Frame)sender).Animate("expand", callback, 15, 185, 5, 500, Easing.CubicInOut);
            IconExpand.TranslateTo(0, IconExpand.Y + 170, 500, Easing.CubicInOut);
            IconExpand.RotateTo(180, 500, Easing.CubicInOut);

        }
        void Collapse(object sender, Xamarin.Forms.SwipedEventArgs e)
        {
            Action<double> callback = input => ((Frame)sender).HeightRequest = input;
            ((Frame)sender).Animate("expand", callback, 175, 15, 5, 500, Easing.CubicInOut);
            IconExpand.TranslateTo(0, 0, 500, Easing.CubicInOut);
            IconExpand.RotateTo(0, 500, Easing.CubicInOut);
             }

    }
}
