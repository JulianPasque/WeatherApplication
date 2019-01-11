using System;
using Prism;
using WeatherApplication.Services.API;
using Xamarin.Essentials;

namespace WeatherApplication.ViewModels
{
    public class LocationBasedWeatherViewModel : WeatherViewModelBase, IActiveAware
    {
        public event EventHandler IsActiveChanged;

        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                SetProperty(ref _isActive, value, RaiseIsActiveChanged);
                if (value)
                {
                    LoadLocation();
                }
            }
        }

        protected virtual void RaiseIsActiveChanged() => IsActiveChanged?.Invoke(this, EventArgs.Empty);

        public async void LoadLocation()
        {

            if ((DateTime.Now - LastRequestTime).TotalMinutes < 10)
            {
                return;
            }
            IsLoading = true;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ErrorMessage = Resources.AppResources.InternetRequired;
                IsLoading = false;
                return;
            }

            try
            {
         
                Location location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {


                    LoadWeather(await WeatherAPI.GetCurrentWeatherForLocation(location.Latitude, location.Longitude),
                                 await WeatherAPI.GetForecastForLocation(location.Latitude, location.Longitude));
                    RequestSuccessfull = true;
                    LastRequestTime = DateTime.Now;
                }
                else
                {
                    ErrorMessage = Resources.AppResources.NoLocation;
                    RequestSuccessfull = false;
                }
            }
            catch (FeatureNotSupportedException)
            {
                ErrorMessage = Resources.AppResources.NotSupported;
                RequestSuccessfull = false;
                // Handle not supported on device exception
            }
            catch (PermissionException)
            {
                ErrorMessage = Resources.AppResources.NoPermission;

                RequestSuccessfull = false;

                // Handle permission exception
            }
            catch (Exception ex)
            {
                ErrorMessage = "Error: " + ex.Message;

                RequestSuccessfull = false;

                // Unable to get location
            }
            IsLoading = false;
        }
    }
}
