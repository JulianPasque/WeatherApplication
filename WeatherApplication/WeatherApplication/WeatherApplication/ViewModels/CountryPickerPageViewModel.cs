using System;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Navigation;
using WeatherApplication.Services;
using WeatherObjects;

namespace WeatherApplication.ViewModels
{
    public class CountryPickerPageViewModel : ViewModelBase
    {
        public CountryPickerPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ItemTappedCommand = new DelegateCommand<Country>(ItemSelected);
            SearchCommand = new DelegateCommand(Filter);
        }

        public ObservableCollection<Country> Countries { get; set; } = new ObservableCollection<Country>(CountryCollection.Countries);

        public DelegateCommand<Country> ItemTappedCommand { get; set; }
        public DelegateCommand SearchCommand { get; set; }

        public string Text { get; set; }

        private void Filter()
        {
            Countries = String.IsNullOrWhiteSpace(Text) ?  new ObservableCollection<Country>(CountryCollection.Countries) : new ObservableCollection<Country>(CountryCollection.Countries.Where(x => x.Name.ToLower().Contains(Text.ToLower())).ToList());
            RaisePropertyChanged(nameof(Countries));
        }

        private async void ItemSelected(Country _SelectedItem)
        {
            NavigationParameters p = new NavigationParameters();
            p.Add("Country", _SelectedItem);
            await NavigationService.GoBackAsync(p);
        }
    }
}
