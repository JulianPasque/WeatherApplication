using System;
using Prism;
using Prism.Commands;
using WeatherApplication.Services.API;

namespace WeatherApplication.ViewModels
{
    public class AdressBasedWeatherViewModel : ViewModelBase, IActiveAware
    {
        public AdressBasedWeatherViewModel()
        {
            ReloadWeather = new DelegateCommand(LoadWeather);
        }

        public DelegateCommand ReloadWeather { get; set; }


        string _Country = "UK";

        public string Country 
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

        public async void LoadWeather()
        {
            try
            {
                LoadWeather(await WeatherAPI.GetWeatherForCity(City, Country));
                RequestSuccessfull = true;

            }
            catch (Exception e)
            {
                RequestSuccessfull = false;
            }

        }

    }
}
