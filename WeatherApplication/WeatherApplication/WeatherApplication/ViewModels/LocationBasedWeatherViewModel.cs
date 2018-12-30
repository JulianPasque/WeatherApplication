using System;
using Prism;
using Prism.Mvvm;
using WeatherApplication.Services.API;
using WeatherObjects;
using Xamarin.Essentials;

namespace WeatherApplication.ViewModels
{
    public class LocationBasedWeatherViewModel : ViewModelBase, IActiveAware
    {

        public event EventHandler IsActiveChanged;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { 
            SetProperty(ref _isActive, value, RaiseIsActiveChanged);
                if (value)
                    LoadLocation();
            }
            }

        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }

        public async void LoadLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    LoadWeather (await WeatherAPI.GetWeatherForLocation(location.Latitude, location.Longitude));

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine("GPS Not supported");
                // Handle not supported on device exception
            }
            catch (PermissionException pEx)
            {
                Console.WriteLine("Permission denied");

                // Handle permission exception
            }
            catch (Exception ex)
            {
                Console.WriteLine("GPS Error: " + ex.Message );

                // Unable to get location
            }
        }

    }
}
