using MetragemRio.Utils;
using System;
using System.ComponentModel;

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

        private string _status;
        public string Status
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

        private DamViewModel _taioDam;
        public DamViewModel TaioDam
        {
            get
            {
                return _taioDam;
            }
            set
            {
                if (value != _taioDam)
                {
                    _taioDam = value;
                    NotifyPropertyChanged("TaioDam");
                }
            }
        }

        private DamViewModel _ituDam;
        public DamViewModel ItuDam
        {
            get
            {
                return _ituDam;
            }
            set
            {
                if (value != _ituDam)
                {
                    _ituDam = value;
                    NotifyPropertyChanged("ItuDam");
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