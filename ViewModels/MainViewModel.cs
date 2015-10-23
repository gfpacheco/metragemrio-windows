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

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<MeterageViewModel> Meterages { get; private set; }

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
            if (!IsDataLoaded)
            {
                Meterages.Clear();
                WebClient webClient = new WebClient();
                webClient.Headers["Accept"] = "application/json";
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompleted);
                webClient.DownloadStringAsync(new Uri(apiUrl));
            }
        }

        public MeterageViewModel getMeterageFromTimestamp(int timestamp)
        {
            return Meterages.Single(ViewModels => ViewModels.Timestamp == timestamp);
        }

        private void webClient_DownloadCatalogCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
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
                    this.IsDataLoaded = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                // TODO: Handle exception
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