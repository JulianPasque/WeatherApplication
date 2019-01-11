using System;
using Newtonsoft.Json;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using WeatherApplication.Services.API;
using WeatherObjects;
using Xamarin.Essentials;

namespace WeatherApplication.ViewModels
{
    public class AdressBasedWeatherViewModel : WeatherViewModelBase, IActiveAware
    {
        public AdressBasedWeatherViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ReloadWeather = new DelegateCommand(LoadWeather);
            SelectCountry = new DelegateCommand(CountrySelection);
        }

        public DelegateCommand ReloadWeather { get; set; }
        public DelegateCommand SelectCountry { get; set; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("Country"))
            {
                Country = parameters.GetValue<Country>("Country");
            }
        }

        public Country Country
        {
            get => JsonConvert.DeserializeObject<Country>(Preferences.Get("Country", JsonConvert.SerializeObject(new Country() { Name = "Germany", CountryCode = "De" })));
            set
            {
                Preferences.Set("Country", JsonConvert.SerializeObject(value));
                RaisePropertyChanged(nameof(Country));
            }
        }

        public string City
        {
            get => Preferences.Get("City", "Köln");
            set
            {
                Preferences.Set("City", value);
                RaisePropertyChanged(nameof(City));
            }
        }

        public event EventHandler IsActiveChanged;

        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value, RaiseIsActiveChanged);
                if (value)
                {
                    LoadWeather();
                }
            }
        }

        protected virtual void RaiseIsActiveChanged() => IsActiveChanged?.Invoke(this, EventArgs.Empty);

        public async void CountrySelection() => await NavigationService.NavigateAsync("CountryPickerPage");

        public async void LoadWeather()
        {
            if ((DateTime.Now - LastRequestTime).TotalMinutes < 10)
            {
                return;
            }

            IsLoading = true;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ErrorMessage = "Internet required";
                IsLoading = false;
                return;
            }
            try
            {
                LoadWeather(await WeatherAPI.GetCurrentWeatherForCity(City, Country.CountryCode),
                            await WeatherAPI.GetForecastForCity(City, Country.CountryCode));
                RequestSuccessfull = true;
                LastRequestTime = DateTime.Now;
            }
            catch (Exception)
            {
                ErrorMessage = "Land und Stadtkombination prüfen";
                RequestSuccessfull = false;
            }
            IsLoading = false;
        }
    }
}
