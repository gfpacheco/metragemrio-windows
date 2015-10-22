using MetragemRio.Utils;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace MetragemRio.ViewModels
{
    public class MeterageViewModel : INotifyPropertyChanged
    {
        private double _timestamp;
        public double Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                if (value != _timestamp)
                {
                    _timestamp = value;
                    NotifyPropertyChanged("Timestamp");
                    NotifyPropertyChanged("DateTime");
                }
            }
        }
        public DateTime Date
        {
            get
            {
                return DateUtils.UnixTimeStampToDateTime(_timestamp);
            }
            set
            {
                _timestamp = DateUtils.DateTimeToUnixTimeStamp(value);
                NotifyPropertyChanged("Timestamp");
                NotifyPropertyChanged("DateTime");
            }
        }

        private int _status;
        public int Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (value != _status)
                {
                    _status = value;
                    NotifyPropertyChanged("Status");
                }
            }
        }

        private double _level;
        public double Level
        {
            get
            {
                return _level;
            }
            set
            {
                if (value != _level)
                {
                    _level = value;
                    NotifyPropertyChanged("Level");
                }
            }
        }

        private double _precipitation;
        public double Precipitation
        {
            get
            {
                return _precipitation;
            }
            set
            {
                if (value != _precipitation)
                {
                    _precipitation = value;
                    NotifyPropertyChanged("Precipitation");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}