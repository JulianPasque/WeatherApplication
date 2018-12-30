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
            Action<double> callback = input => ((StackLayout)sender).HeightRequest = input;
            ((StackLayout)sender).Animate("expand", callback, 15, 165, 5, 500, Easing.CubicIn);


            //Action<double> callback2 = input => StkAdressEntry.HeightRequest = input;
            //StkAdressEntry.Animate("invis", callback2, 0, 90, 5, 500, Easing.CubicIn);



        }
        void Collapse(object sender, Xamarin.Forms.SwipedEventArgs e)
        {
            Action<double> callback = input => ((StackLayout)sender).HeightRequest = input;
            ((StackLayout)sender).Animate("expand", callback, 165, 15, 5, 500, Easing.CubicOut);

            //Action<double> callback2 = input => StkAdressEntry.HeightRequest = input;
            //StkAdressEntry.Animate("invis", callback2, 90, 0, 5, 500, Easing.CubicOut);


        }

    }
}
