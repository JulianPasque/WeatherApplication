using System;
using System.Threading.Tasks;
using Prism;
using Prism.Navigation;
using WeatherApplication.Services.API;
using WeatherObjects;

namespace WeatherApplication.ViewModels
{
    public class WeatherOverviewViewModel : ViewModelBase
    {
        public WeatherOverviewViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

    }
}
