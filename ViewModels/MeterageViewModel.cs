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
        private string _timestamp;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public string Timestamp
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
                }
            }
        }

        private string _status;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
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

        private string _level;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Level
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

        private string _precipitation;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string Precipitation
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