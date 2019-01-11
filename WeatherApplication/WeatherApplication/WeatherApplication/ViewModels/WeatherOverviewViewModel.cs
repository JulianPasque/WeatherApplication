using Prism.Navigation;

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
