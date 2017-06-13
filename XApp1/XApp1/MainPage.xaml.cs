
using Java.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XApp1
{
   	public partial class MainPage : ContentPage
	{        

        public class ImageEventArgs : EventArgs
        {
            public SlideShow slideShowArg { get; set; }
        }

        public MainPage()
		{
			InitializeComponent();

            MainPageViewModel vm = new MainPageViewModel();

            BindingContext = vm;

            listViewForecast.ItemsSource = vm.WeatherDataForecastProp;
            //BindingContext = new DigitalClockViewModel();
            //LoadApplication(new PhotoFrameXamarin.App());
            /*
                        //poveži se na weather api - trenutno vrijeme
                        RestClient restClient = new RestClient();
                        restClient.EndPoint = "http://api.openweathermap.org/data/2.5/weather?q=Zagreb,HR&units=metric&appid=afd75004902d6b7f60f880ff6322266f&lang=hr";
                        string strResponse = restClient.MakeRequest();

            
                        //Učitaj podatke lokalno
                        WeatherData weatherData = new WeatherData();
                        weatherData.PopulateProperties(strResponse);
                        //
                        //

                        //prikaži dan, datum i sat
                        txtDay.Text = DateTime.Now.ToString("dddd").ToUpper();
                        txtDate.Text = DateTime.Now.ToString("dd.MM.yy");

                        //uključi timer za prikazivanje vremena
                        try
                        {
                            StartTimerClock();
                        }
                        catch (Exception ex)
                        {
                            txtStatus.Text = "Greška: " + ex.Message;
                        }
                        //

                        //uključi slideshow            
                        SlideShow slideShow = new SlideShow();
                        slideShow.DirPath = @"C:\Users\mile.mrkobrad\Documents\visual studio 2017\Projects\PhotoFrame\PhotoFrame\Resources";
                        try
                        {
                            slideShow.CreateList();
                            StartTimerSlideShow(new ImageEventArgs { slideShowArg = slideShow });
                        }
                        catch (Exception ex)
                        {
                            txtStatus.Text = "Greška: " + ex.Message;
                        }
                        //

                        //forecast
                        //poveži se na weather api - trenutno vrijeme
                        RestClient restClientF = new RestClient();
                        restClientF.EndPoint = "http://api.openweathermap.org/data/2.5/forecast?q=Zagreb,HR&units=metric&appid=afd75004902d6b7f60f880ff6322266f&lang=hr";
                        string strResponseF = restClientF.MakeRequest();

                        WeatherData weatherDataForecast = new WeatherData();
                        ObservableCollection<WeatherData> forecast = new ObservableCollection<WeatherData>();
                        forecast = weatherDataForecast.PopulatePropertiesForecast(strResponseF);
                        //

                        //DataContext = new
                        //{
                        //    weatherData,
                        //    forecast
                        //};
                        */
        }

        //public static void StartTimerClock()
        //{
        //    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        //    {
        //        OnSecondChanged();
        //        return true;
        //    });
        //}
        //private static void OnSecondChanged()
        //{
        //    DateTime d = DateTime.Now;
        //    //txtTime.Text = d.ToString("HH:mm");
        //}


        //public static void StartTimerSlideShow(ImageEventArgs slideShowArg)
        //{
        //    Device.StartTimer(TimeSpan.FromSeconds(3), () =>
        //    {
        //        OnImageSpan(slideShowArg);
        //        return true;
        //    });
        //}

        //private static void OnImageSpan(ImageEventArgs slideShowArg)
        //{
        //    string argPath = slideShowArg.slideShowArg.GetNextImage();
        //    /*
        //    if (File.Exists(argPath))
        //    {
        //        BitmapImage image = new BitmapImage();
        //        image.BeginInit();
        //        image.UriSource = new Uri(argPath);
        //        image.EndInit();

        //        imgPhoto.Source = image;
        //    }*/
        //}

        
    }

}
