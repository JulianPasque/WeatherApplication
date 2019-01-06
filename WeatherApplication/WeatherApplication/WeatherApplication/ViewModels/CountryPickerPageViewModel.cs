using System;
using Prism.Commands;
using Prism.Navigation;
using WeatherObjects;

namespace WeatherApplication.ViewModels
{
    public class CountryPickerPageViewModel : ViewModelBase
    {
        public CountryPickerPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ItemTappedCommand = new DelegateCommand<Country>(ItemSelected);
        }

        public DelegateCommand<Country> ItemTappedCommand { get; set; }

        private async void ItemSelected (Country _SelectedItem)
        {
            NavigationParameters p = new NavigationParameters();
            p.Add("Country", _SelectedItem);
            await NavigationService.GoBackAsync(p);
        }
    }
}
