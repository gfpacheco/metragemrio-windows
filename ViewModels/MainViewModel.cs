using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MetragemRio.Resources;
using System.Net;
using Newtonsoft.Json;
using MetragemRio.Models;
using System.Diagnostics;
using System.Linq;

namespace MetragemRio.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        const string apiUrl = @"http://54.232.230.246:5001/";

        public MainViewModel()
        {
            this.Meterages = new ObservableCollection<MeterageViewModel>();
            this.Meterages.OrderByDescending(meterage => meterage.Timestamp);
        }

        public ObservableCollection<MeterageViewModel> Meterages { get; private set; }

        private bool _isLoading = false;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            private set
            {
                if (value != _isLoading)
                {
                    _isLoading = value;
                    NotifyPropertyChanged("IsLoading");
                }
            }
        }

        private bool _hasError = false;
        public bool HasError
        {
            get
            {
                return _hasError;
            }
            private set
            {
                if (value != _hasError)
                {
                    _hasError = value;
                    NotifyPropertyChanged("HasError");
                }
            }
        }

        public void LoadData()
        {
            this.HasError = false;
            if (!this.IsLoading)
            {
                this.IsLoading = true;
                this.Meterages.Clear();
                WebClient webClient = new WebClient();
                webClient.Headers["Accept"] = "application/json";
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompleted);
                webClient.DownloadStringAsync(new Uri(apiUrl));
            }
        }

        public MeterageViewModel getMeterageFromTimestamp(int timestamp)
        {
            return this.Meterages.Single(ViewModels => ViewModels.Timestamp == timestamp);
        }

        private void webClient_DownloadCatalogCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.IsLoading = false;
            try
            {
                this.Meterages.Clear();
                if (e.Result != null)
                {
                    var meterages = JsonConvert.DeserializeObject<Meterage[]>(e.Result);
                    int id = 0;
                    foreach (Meterage meterage in meterages)
                    {
                        this.Meterages.Add(new MeterageViewModel()
                        {
                            Timestamp = meterage.timestamp,
                            Status = meterage.status,
                            Level = meterage.level
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                HasError = true;
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