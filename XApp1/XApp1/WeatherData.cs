using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;

namespace XApp1
{
    public class WeatherData
    {
        string dt = String.Empty;
        string description = String.Empty;
        string iconUrl = String.Empty;
        string temp = String.Empty;
        string pressure = String.Empty;
        string humidity = String.Empty;
        string tempMin = String.Empty;
        string tempMax = String.Empty;
        string windSpeed = String.Empty;
        string sunrise = String.Empty;
        string sunset = String.Empty;

        public WeatherData()
        {
            WindSpeed = "0";           
        }

        public void GetWeatherData()
        {
            RestClient rc = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=Zagreb,HR&units=metric&appid=afd75004902d6b7f60f880ff6322266f&lang=hr");
            PopulateProperties(rc.Response);
        }

        public ObservableCollection<WeatherData> GetWeatherForecastData()
        {
            RestClient rcForecast = new RestClient("http://api.openweathermap.org/data/2.5/forecast?q=Zagreb,HR&units=metric&appid=afd75004902d6b7f60f880ff6322266f&lang=hr");
            return PopulatePropertiesForecast(rcForecast.Response);
        }

        public string Dt
        {
            get
            {
                string _res;
                try
                {
                    _res = ConvertUnixDate.ConvertOutputDateTime(Double.Parse(dt));
                }
                catch
                {
                    _res = "";
                }
                return _res;
            }
            set
            {
                dt = value;
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
            }
        }
        public string Temp
        {
            get
            {
               return Helper.MyRound(temp, "°C");
            }
            set
            {
                temp = value;
            }
        }
        public string Pressure
        {
            get
            {
                return pressure + "hPa";
            }
            set
            {
                pressure = value;
            }
        }
        public string Humidity
        {
            get
            {
                return humidity + "%";
            }
            set
            {
                humidity = value;
            }
        }

        public string TempMin
        {
            get
            {
                return tempMin + "°C";
            }
            set
            {
                tempMin = value;
            }
        }
        public string TempMax
        {
            get
            {
                return tempMax + "°C";
            }
            set
            {
                tempMax = value;
            }
        }
        public string WindSpeed
        {
            get
            {
                return Helper.MyRound(windSpeed, "km/h");
            }
            set
            {
                windSpeed = value;
            }
        }
        public string Sunrise
        {
            get
            {
                return ConvertUnixDate.ConvertOutputTime(Double.Parse(sunrise));
            }
            set
            {
                sunrise = value;
            }
        }
        public string Sunset
        {
            get
            {
                return ConvertUnixDate.ConvertOutputTime(Double.Parse(sunset));
            }
            set
            {
                sunset = value;
            }
        }

        //public ObservableCollection<WeatherData> ObservableForecast { get; set; }



        public void PopulateProperties(string jsonString)
        {
            dynamic data = JObject.Parse(jsonString);
            Description = (string)data["weather"][0]["description"];
            IconUrl = (string)data["weather"][0]["icon"];
            Temp = (string)data["main"]["temp"];
            Pressure = (string)data["main"]["pressure"];
            Humidity = (string)data["main"]["humidity"];
            TempMin = (string)data["main"]["temp_min"];
            TempMax = (string)data["main"]["temp_max"];
            WindSpeed = (string)data["wind"]["speed"];
            Sunrise = (string)data["sys"]["sunrise"];
            Sunset = (string)data["sys"]["sunset"];
        }

        public ObservableCollection<WeatherData> PopulatePropertiesForecast(string jsonString)
        {
            dynamic data = JObject.Parse(jsonString);
            ObservableCollection<WeatherData> weatherData = new ObservableCollection<WeatherData>();
            for (int i = 0; i < 25; i++)
            {
                weatherData.Add(
                    new WeatherData()
                    {
                        Dt = (string)data["list"][i]["dt"],
                        Description = (string)data["list"][i]["weather"][0]["description"],
                        IconUrl = (string)data["list"][i]["weather"][0]["icon"],
                        Temp = (string)data["list"][i]["main"]["temp"],
                        Pressure = (string)data["list"][i]["main"]["pressure"],
                        Humidity = (string)data["list"][i]["main"]["humidity"],
                        TempMin = (string)data["list"][i]["main"]["temp_min"],
                        TempMax = (string)data["list"][i]["main"]["temp_max"],
                        WindSpeed = (string)data["list"][i]["wind"]["speed"]                    
                    }
                );
            }

            return weatherData;
        }
    }

}
