using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApplication.Services.API;
using Xamarin.Forms;

namespace WeatherApplication.Views
{
    public partial class WeatherOverview : TabbedPage
    {
        public WeatherOverview()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

        }

    }
}
