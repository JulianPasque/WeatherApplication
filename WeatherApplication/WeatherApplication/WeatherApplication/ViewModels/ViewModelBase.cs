using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherObjects;

namespace WeatherApplication.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }


        public ViewModelBase()
        {
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public void LoadWeather(WeatherContainer weatherContainer, WeatherForecastContainer WeatherForecast)
        {
            
            CityName = weatherContainer.name;
            CurrentTemp = weatherContainer.main.temp;
            SunRise = UnixTimeStampToDateTime(weatherContainer.sys.sunrise);
            SunSet = UnixTimeStampToDateTime(weatherContainer.sys.sunset);
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        bool _RequestSuccessfull;
        public bool RequestSuccessfull
        {
            get
            {
                return _RequestSuccessfull;
            }
            set
            {
                if (_RequestSuccessfull == value)
                    return;
                _RequestSuccessfull = value;
                RaisePropertyChanged(nameof(RequestSuccessfull));
            }
        }

        string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                if (_Message == value)
                    return;
                _Message = value;
                RaisePropertyChanged(nameof(Message));
            }
        }


        string _CityName;
        public string CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                if (_CityName == value)
                    return;
                _CityName = value;
                RaisePropertyChanged(nameof(CityName));
                }
            }


        private double _CurrentTemp;
        public double CurrentTemp
        {
            get
            {
                return _CurrentTemp;
            }
            set
            {
                if (_CurrentTemp == value)
                    return;
                _CurrentTemp = value;
                RaisePropertyChanged(nameof(CurrentTemp));
            }
        }

        private DateTime _SunRise;
        public DateTime SunRise
        {
            get
            {
                return _SunRise;
            }
            set
            {
                if (_SunRise == value)
                    return;
                _SunRise = value;
                RaisePropertyChanged(nameof(SunRise));
            }
        }

        private DateTime _SunSet;
        public DateTime SunSet
        {
            get
            {
                return _SunSet;
            }
            set
            {
                if (_SunSet == value)
                    return;
                _SunSet = value;
                RaisePropertyChanged(nameof(SunSet));
            }
        }


    }
}
