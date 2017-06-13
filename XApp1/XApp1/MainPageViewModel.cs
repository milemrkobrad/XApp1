using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XApp1
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        string clockLabel;
        string dateLabel;
        WeatherData weatherData;
        string dt;
        string description = "";
        string iconUrl = "";
        string temp = "";
        string pressure = "";
        string humidity = "";
        string windSpeed = "";
        string sunrise;
        string sunset;
        ObservableCollection<WeatherData> weatherDataForecastProp;

        public string ClockLabel
        {
            get
            {
                return clockLabel;
            }
            set
            {
                clockLabel = value;
                OnPropertyChanged("ClockLabel");
            }
        }

        public string DateLabel
        {
            get
            {
                return dateLabel;
            }
            set
            {
                dateLabel = value;
                OnPropertyChanged("DateLabel");
            }
        }

        public WeatherData WeatherDataProp
        {
            get
            {
                return weatherData;
            }
            set
            {
                weatherData = value;
                OnPropertyChanged("WeatherData");
            }
        }

        public string Dt
        {
            get
            {                
                return dt;
            }
            set
            {
                dt = value;
                OnPropertyChanged("Dt");
            }
        }

        public string Description
        {
            get
            {
                return description.ToUpper();
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public string IconUrl
        {
            get
            {
                return "http://openweathermap.org/img/w/" + iconUrl + ".png";
            }
            set
            {
                iconUrl = value;
                OnPropertyChanged("IconUrl");
            }
        }

        public string Temp
        {
            get
            {
                return temp;
            }
            set
            {
                temp = value;
                OnPropertyChanged("Temp");
            }
        }

        public string Pressure
        {
            get
            {
                return pressure;
            }
            set
            {
                pressure = value;
                OnPropertyChanged("Pressure");
            }
        }
        public string Humidity
        {
            get
            {
                return humidity;
            }
            set
            {
                humidity = value;
                OnPropertyChanged("Humidity");
            }
        }

        public string WindSpeed
        {
            get
            {
                return windSpeed;
            }
            set
            {
                windSpeed = value;
                OnPropertyChanged("WindSpeed");
            }
        }
        public string Sunrise
        {
            get
            {
                return sunrise;
            }
            set
            {
                sunrise = value;
                OnPropertyChanged("Sunrise");
            }
        }
        public string Sunset
        {
            get
            {
                return sunset;
            }
            set
            {
                sunset = value;
                OnPropertyChanged("Sunset");
            }
        }

        public ObservableCollection<WeatherData> WeatherDataForecastProp
        {
            get
            {
                return weatherDataForecastProp;
            }
            set
            {
                weatherDataForecastProp = value;
                OnPropertyChanged("WeatherDataForecastProp");
            }
        }



        public MainPageViewModel()
        {
            // Start the timer going.
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);

            Device.StartTimer(TimeSpan.FromSeconds(10), OnTimerWeather);

            //Device.StartTimer(TimeSpan.FromSeconds(15), OnTimerWeatherForecast);
        }

        bool OnTimerTick()
        {
            // Set the Text property of the Label.
            ClockLabel = DateTime.Now.ToString("HH:mm:ss");
            DateLabel = DateTime.Now.ToString("dd.MM.yyyy");
            return true;
        }

        bool OnTimerWeather()
        {
            //Učitaj podatke lokalno
            WeatherData wd = new WeatherData();
            wd.GetWeatherData();
            WeatherDataProp = wd;
            
            Dt = wd.Dt;
            Description = wd.Description;
            IconUrl = wd.IconUrl;
            Temp = wd.Temp;
            Pressure = wd.Pressure;
            Humidity = wd.Humidity;
            WindSpeed = wd.WindSpeed;
            Sunrise = wd.Sunrise;
            Sunset = wd.Sunset;

            WeatherData wdForecast = new WeatherData();
            WeatherDataForecastProp = wdForecast.GetWeatherForecastData();
            //
            return true;
        }

        //bool OnTimerWeatherForecast()
        //{
        //    //Učitaj podatke lokalno
        //    WeatherData wd = new WeatherData();
        //    WeatherDataProp = wd;
        //    WeatherDataForecastProp = wd.ObservableForecast;            
        //    //
        //    return true;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
