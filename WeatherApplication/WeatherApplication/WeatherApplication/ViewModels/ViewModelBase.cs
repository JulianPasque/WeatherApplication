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

        public void LoadWeather(WeatherContainer weatherContainer)
        {
            
            CityName = weatherContainer.name;
            CurrentTemp = weatherContainer.main.temp;
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

    }
}
