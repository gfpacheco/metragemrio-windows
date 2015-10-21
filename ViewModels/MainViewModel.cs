﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MetragemRio.Resources;

namespace MetragemRio.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<MeterageViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<MeterageViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new MeterageViewModel() { Timestamp = "0", Status = "runtime one", Level = "Maecenas praesent accumsan bibendum", Precipitation = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "1", Status = "runtime two", Level = "Dictumst eleifend facilisi faucibus", Precipitation = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "2", Status = "runtime three", Level = "Habitant inceptos interdum lobortis", Precipitation = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "3", Status = "runtime four", Level = "Nascetur pharetra placerat pulvinar", Precipitation = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "4", Status = "runtime five", Level = "Maecenas praesent accumsan bibendum", Precipitation = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "5", Status = "runtime six", Level = "Dictumst eleifend facilisi faucibus", Precipitation = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "6", Status = "runtime seven", Level = "Habitant inceptos interdum lobortis", Precipitation = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "7", Status = "runtime eight", Level = "Nascetur pharetra placerat pulvinar", Precipitation = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "8", Status = "runtime nine", Level = "Maecenas praesent accumsan bibendum", Precipitation = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "9", Status = "runtime ten", Level = "Dictumst eleifend facilisi faucibus", Precipitation = "Suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "10", Status = "runtime eleven", Level = "Habitant inceptos interdum lobortis", Precipitation = "Habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "11", Status = "runtime twelve", Level = "Nascetur pharetra placerat pulvinar", Precipitation = "Ultrices vehicula volutpat maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "12", Status = "runtime thirteen", Level = "Maecenas praesent accumsan bibendum", Precipitation = "Maecenas praesent accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "13", Status = "runtime fourteen", Level = "Dictumst eleifend facilisi faucibus", Precipitation = "Pharetra placerat pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "14", Status = "runtime fifteen", Level = "Habitant inceptos interdum lobortis", Precipitation = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
            this.Items.Add(new MeterageViewModel() { Timestamp = "15", Status = "runtime sixteen", Level = "Nascetur pharetra placerat pulvinar", Precipitation = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });

            this.IsDataLoaded = true;
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