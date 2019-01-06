using System;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using WeatherApplication.Services.API;
using WeatherObjects;

namespace WeatherApplication.ViewModels
{
    public class AdressBasedWeatherViewModel : ViewModelBase, IActiveAware
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

        Country _Country = new Country() { Name = "United Kingdom", CountryCode = "GB" };

        public Country Country 
        {
            get
            {
                return _Country;
            }
            set
            {
                if (_Country == value)
                    return;
                _Country = value;
                RaisePropertyChanged(nameof(Country));
            }
        }

        string _City = "London";

        public string City 
        {
            get
            {
                return _City;
            }
            set
            {
                if (_City == value)
                    return;
                _City = value;
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
                    LoadWeather();
            }
        }

        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }

        public async void CountrySelection()
        {
            await NavigationService.NavigateAsync("CountryPickerPage");


        }

        public async void LoadWeather()
        {
            try
            {
                LoadWeather(await WeatherAPI.GetCurrentWeatherForCity(City, Country.CountryCode),
                            await WeatherAPI.GetForecastForCity(City, Country.CountryCode));
                RequestSuccessfull = true;

            }
            catch (Exception e)
            {
                RequestSuccessfull = false;
            }

        }

    }
}
