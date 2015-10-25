using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage;
using MetragemRio.Models;
using System.Collections;

namespace MetragemRio
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        AppSettings Settings;
        private List<string> LevelOptions = new List<string> {
            "Não me notifique",
            "6 metros",
            "7 metros",
            "8 metros",
            "9 metros",
            "10 metros",
            "11 metros"
        };

        public SettingsPage()
        {
            InitializeComponent();

            Settings = new AppSettings();
            this.NotificationLevelListPicker.ItemsSource = LevelOptions;
            this.NotificationLevelListPicker.SelectedIndex = MeterToIndex(Settings.NotificationLevelSetting);
        }

        private int StartsAt = 5;

        private int IndexToMeter(int index)
        {
            if (index == 0)
                return -1;

            return index + StartsAt;
        }

        private int MeterToIndex(int meter)
        {
            if (meter == -1)
                return 0;

            return meter - StartsAt;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            
            Settings.NotificationLevelSetting = IndexToMeter(this.NotificationLevelListPicker.SelectedIndex);

            if (Settings.NotificationLevelSetting == -1)
            {
                App.unsubscribe();
            }
            else
            {
                App.subscribeForLevel(Settings.NotificationLevelSetting);
            }
        }
    }
}