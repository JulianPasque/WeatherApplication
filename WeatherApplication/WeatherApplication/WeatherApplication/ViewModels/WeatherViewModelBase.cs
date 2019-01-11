using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using WeatherObjects;

namespace WeatherApplication.ViewModels
{
    public class WeatherViewModelBase : ViewModelBase
    {
        public WeatherViewModelBase()
        {
        }

        public WeatherViewModelBase(INavigationService navigationService) : base(navigationService)
        {
        }

        public void LoadWeather(WeatherContainer weatherContainer, WeatherForecastContainer WeatherForecast)
        {
            CityName = weatherContainer.name;
            CurrentTemp = weatherContainer.main.temp;

            DateTime Sunrise = UnixTimeStampToDateTime(weatherContainer.sys.sunrise);
            DateTime Sunset = UnixTimeStampToDateTime(weatherContainer.sys.sunset);

            List<ForecastObject> Forecasts = new List<ForecastObject>(6);

            for (int i = 0; i < 6; ++i)
            {
                Forecasts.Add(new ForecastObject()
                {
                    Time = UnixTimeStampToDateTime(WeatherForecast.list[i].dt),//new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddHours(NextForecast),
                    Temperatur = WeatherForecast.list[i].main.temp,
                    Weather = WeatherForecast.list[i].weather[0]
                });
            }
            bool SunriseAdded = false;
            bool SunsetAdded = false;

            for (int i = 0; i < Forecasts.Count; ++i)
            {
                TimeSpan SunriseDif = (Sunrise - Forecasts[i].Time);
                TimeSpan SunsetDif = (Sunset - Forecasts[i].Time);
                if (SunriseDif < new TimeSpan(0, 0, 0) && SunriseDif.Hours > -3 && !SunriseAdded)
                {
                    SetNextHourlyForecast(new ForecastObject()
                    {
                        Time = Sunrise,
                        Weather = new Weather() { id = 900 }
                    });
                    SunriseAdded = true;
                    i--;
                }
                else if (SunsetDif < new TimeSpan(0, 0, 0) && SunsetDif.Hours > -3 && !SunsetAdded)
                {
                    SetNextHourlyForecast(new ForecastObject()
                    {
                        Time = Sunset,
                        Weather = new Weather() { id = 901 }
                    });
                    SunsetAdded = true;
                    i--;
                }
                else
                {
                    SetNextHourlyForecast(Forecasts[i]);
                }
            }

            for (int ahead = 1; ahead < 5; ++ahead)
            {
                var List = WeatherForecast.list.Where(x => UnixTimeStampToDateTime(x.dt).Date == DateTime.Now.AddDays(ahead).Date).ToList();

                SetNextDailyForecast(new ForecastObject
                {
                    MinTemperatur = List.Min(x => x.main.temp_min),
                    MaxTemperatur = List.Max(x => x.main.temp_max),
                    Time = DateTime.Now.AddDays(ahead),
                    Weather = List.Where(x => UnixTimeStampToDateTime(x.dt).TimeOfDay >= new TimeSpan(11, 0, 0) && UnixTimeStampToDateTime(x.dt).TimeOfDay < new TimeSpan(14, 0, 0)).First().weather[0]
                });
            }
        }

        private void SetNextHourlyForecast(ForecastObject forecast)
        {
            if (HourlyForecast1 == null)
            {
                HourlyForecast1 = forecast;
            }
            else if (HourlyForecast2 == null)
            {
                HourlyForecast2 = forecast;
            }
            else if (HourlyForecast3 == null)
            {
                HourlyForecast3 = forecast;
            }
            else if (HourlyForecast4 == null)
            {
                HourlyForecast4 = forecast;
            }
            else if (HourlyForecast5 == null)
            {
                HourlyForecast5 = forecast;
            }
            else if (HourlyForecast6 == null)
            {
                HourlyForecast6 = forecast;
            }
        }

        private void SetNextDailyForecast(ForecastObject forecast)
        {
            if (DailyForecast1 == null)
            {
                DailyForecast1 = forecast;
            }
            else if (DailyForecast2 == null)
            {
                DailyForecast2 = forecast;
            }
            else if (DailyForecast3 == null)
            {
                DailyForecast3 = forecast;
            }
            else if (DailyForecast4 == null)
            {
                DailyForecast4 = forecast;
            }
            else if (DailyForecast5 == null)
            {
                DailyForecast5 = forecast;
            }
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        private bool _RequestSuccessfull;

        public bool RequestSuccessfull
        {
            get => _RequestSuccessfull;
            set
            {
                if (_RequestSuccessfull == value)
                {
                    return;
                }

                _RequestSuccessfull = value;
                RaisePropertyChanged(nameof(RequestSuccessfull));
            }
        }

        private string _ErrorMessage;

        public string ErrorMessage
        {
            get => _ErrorMessage;
            set
            {
                if (_ErrorMessage == value)
                {
                    return;
                }

                _ErrorMessage = value;
                RaisePropertyChanged(nameof(ErrorMessage));
            }
        }

        public DateTime LastRequestTime = new DateTime(1970, 1, 1);

        private bool _IsLoading;

        public bool IsLoading
        {
            get => _IsLoading;
            set
            {
                if (_IsLoading == value)
                {
                    return;
                }

                _IsLoading = value;
                RaisePropertyChanged(nameof(IsLoading));
            }
        }

        private string _Message;

        public string Message
        {
            get => _Message;
            set
            {
                if (_Message == value)
                {
                    return;
                }

                _Message = value;
                RaisePropertyChanged(nameof(Message));
            }
        }

        private string _CityName;

        public string CityName
        {
            get => _CityName;
            set
            {
                if (_CityName == value)
                {
                    return;
                }

                _CityName = value;
                RaisePropertyChanged(nameof(CityName));
            }
        }

        private double _CurrentTemp;

        public double CurrentTemp
        {
            get => _CurrentTemp;
            set
            {
                if (_CurrentTemp == value)
                {
                    return;
                }

                _CurrentTemp = value;
                RaisePropertyChanged(nameof(CurrentTemp));
            }
        }

        private ForecastObject _HourlyForecast1;

        public ForecastObject HourlyForecast1
        {
            get => _HourlyForecast1;
            set
            {
                if (_HourlyForecast1 != value)
                {
                    _HourlyForecast1 = value;
                    RaisePropertyChanged(nameof(HourlyForecast1));
                }
            }
        }

        private ForecastObject _HourlyForecast2;

        public ForecastObject HourlyForecast2
        {
            get => _HourlyForecast2;
            set
            {
                if (_HourlyForecast2 != value)
                {
                    _HourlyForecast2 = value;
                    RaisePropertyChanged(nameof(HourlyForecast2));
                }
            }
        }

        private ForecastObject _HourlyForecast3;

        public ForecastObject HourlyForecast3
        {
            get => _HourlyForecast3;
            set
            {
                if (_HourlyForecast3 != value)
                {
                    _HourlyForecast3 = value;
                    RaisePropertyChanged(nameof(HourlyForecast3));
                }
            }
        }

        private ForecastObject _HourlyForecast4;

        public ForecastObject HourlyForecast4
        {
            get => _HourlyForecast4;
            set
            {
                if (_HourlyForecast4 != value)
                {
                    _HourlyForecast4 = value;
                    RaisePropertyChanged(nameof(HourlyForecast4));
                }
            }
        }

        private ForecastObject _HourlyForecast5;

        public ForecastObject HourlyForecast5
        {
            get => _HourlyForecast5;
            set
            {
                if (_HourlyForecast5 != value)
                {
                    _HourlyForecast5 = value;
                    RaisePropertyChanged(nameof(HourlyForecast5));
                }
            }
        }

        private ForecastObject _HourlyForecast6;

        public ForecastObject HourlyForecast6
        {
            get => _HourlyForecast6;
            set
            {
                if (_HourlyForecast6 != value)
                {
                    _HourlyForecast6 = value;
                    RaisePropertyChanged(nameof(HourlyForecast6));
                }
            }
        }

        private ForecastObject _DailyForecast1;

        public ForecastObject DailyForecast1
        {
            get => _DailyForecast1;
            set
            {
                if (_DailyForecast1 != value)
                {
                    _DailyForecast1 = value;
                    RaisePropertyChanged(nameof(DailyForecast1));
                }
            }
        }

        private ForecastObject _DailyForecast2;

        public ForecastObject DailyForecast2
        {
            get => _DailyForecast2;
            set
            {
                if (_DailyForecast2 != value)
                {
                    _DailyForecast2 = value;
                    RaisePropertyChanged(nameof(DailyForecast2));
                }
            }
        }

        private ForecastObject _DailyForecast3;

        public ForecastObject DailyForecast3
        {
            get => _DailyForecast3;
            set
            {
                if (_DailyForecast3 != value)
                {
                    _DailyForecast3 = value;
                    RaisePropertyChanged(nameof(DailyForecast3));
                }
            }
        }

        private ForecastObject _DailyForecast4;

        public ForecastObject DailyForecast4
        {
            get => _DailyForecast4;
            set
            {
                if (_DailyForecast4 != value)
                {
                    _DailyForecast4 = value;
                    RaisePropertyChanged(nameof(DailyForecast4));
                }
            }
        }

        private ForecastObject _DailyForecast5;

        public ForecastObject DailyForecast5
        {
            get => _DailyForecast5;
            set
            {
                if (_DailyForecast5 != value)
                {
                    _DailyForecast5 = value;
                    RaisePropertyChanged(nameof(DailyForecast5));
                }
            }
        }
    }
}
