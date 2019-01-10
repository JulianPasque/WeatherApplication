﻿using System;
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
            IsLoading = true;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                ErrorMessage = "Internet required";
                IsLoading = false;
                return;
            }

            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    LoadWeather (await WeatherAPI.GetCurrentWeatherForLocation(location.Latitude, location.Longitude), 
                                 await WeatherAPI.GetForecastForLocation(location.Latitude, location.Longitude));
                    RequestSuccessfull = true;
                }
            }
            catch (FeatureNotSupportedException ex)
            {
                Console.WriteLine("GPS Not supported");
                ErrorMessage = "GPS Not supported";
                RequestSuccessfull = false;
                // Handle not supported on device exception
            }
            catch (PermissionException ex)
            {
                ErrorMessage = "Permission denied";

                Console.WriteLine("Permission denied");
                RequestSuccessfull = false;

                // Handle permission exception
            }
            catch (Exception ex)
            {
                ErrorMessage = "GPS Error: " + ex.Message;

                Console.WriteLine("GPS Error: " + ex.Message );
                RequestSuccessfull = false;

                // Unable to get location
            }
            IsLoading = false;
        }

    }
}
