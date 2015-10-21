using System;
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
            this.Items.Add(new MeterageViewModel() { Timestamp = 0, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 1, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 2, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 3, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 4, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 5, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 6, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 7, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 8, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 9, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 10, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 11, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 12, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 13, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 14, Status = 1, Level = 7.32, Precipitation = 22 });
            this.Items.Add(new MeterageViewModel() { Timestamp = 15, Status = 1, Level = 7.32, Precipitation = 22 });

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