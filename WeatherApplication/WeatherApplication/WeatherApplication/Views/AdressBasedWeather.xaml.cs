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

        bool Expanded = false;
        public void Expand()
        {
            Action<double> callback = input => FrameBorder.HeightRequest = input;

            if (Expanded)
            {
                FrameBorder.Animate("expand", callback, 175, 15, 5, 500, Easing.CubicInOut);
                IconExpand.TranslateTo(0, 0, 500, Easing.CubicInOut);
                IconExpand.RotateTo(0, 500, Easing.CubicInOut);
            }
            else
            {

           
            FrameBorder.Animate("expand", callback, 15, 185, 5, 500, Easing.CubicInOut);
            IconExpand.TranslateTo(0, IconExpand.Y + 170, 500, Easing.CubicInOut);
            IconExpand.RotateTo(180, 500, Easing.CubicInOut);
            }
            Expanded = !Expanded;
        }

        void Expand(object sender, Xamarin.Forms.SwipedEventArgs e)
        {
            Expand();

        }

        void BtnExpand(object sender, Xamarin.Forms.TappedEventArgs e)
        {
            Expand();

        }

        void Handle_Swiped(object sender, Xamarin.Forms.SwipedEventArgs e)
        {
            Expand();
        }
    }
}
