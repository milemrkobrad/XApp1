using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace XApp1
{
    public class DigitalClockViewModel : INotifyPropertyChanged
    {
        string clockLabel;
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

        public DigitalClockViewModel()
        {
            // Start the timer going.
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }

        bool OnTimerTick()
        {
            // Set the Text property of the Label.
            ClockLabel = DateTime.Now.ToString("HH:mm");
            return true;
        }

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

