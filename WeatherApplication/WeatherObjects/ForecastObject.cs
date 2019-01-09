using System;
using System.ComponentModel;

namespace WeatherObjects
{
    public class ForecastObject : INotifyPropertyChanged
    {
        DateTime _Time;

        public DateTime Time { 
            get
            {
                return _Time;
            }
            set
            {
                if (_Time != value)
                {
                    _Time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }

        double _Temperatur;
        public double Temperatur
        {
            get
            {
                return _Temperatur;
            }
            set
            {
                if (_Temperatur != value)
                {
                    _Temperatur = value;
                    OnPropertyChanged(nameof(Temperatur));
                }
            }
        }

        Weather _Weather;
        public Weather Weather
        {
            get
            {
                return _Weather;
            }
            set
            {
                if (_Weather != value)
                {
                    _Weather = value;
                    OnPropertyChanged(nameof(Weather));
                }
            }
        }

        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
