using System;
using System.IO.IsolatedStorage;

namespace MetragemRio.Models
{
    class AppSettings
    {
        IsolatedStorageSettings settings;

        const string NotificationLevelKeyName = "NotificationLevel";
        const int NotificationLevelDefault = -1;

        public AppSettings()
        {
            settings = IsolatedStorageSettings.ApplicationSettings;
        }

        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            if (settings.Contains(Key))
            {
                if (settings[Key] != value)
                {
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }

            return valueChanged;
        }

        public T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;

            if (settings.Contains(Key))
            {
                value = (T)settings[Key];
            }
            else
            {
                value = defaultValue;
            }

            return value;
        }

        public void Save()
        {
            settings.Save();
        }

        public int NotificationLevelSetting
        {
            get
            {
                return GetValueOrDefault<int>(NotificationLevelKeyName, NotificationLevelDefault);
            }
            set
            {
                if (AddOrUpdateValue(NotificationLevelKeyName, value))
                {
                    Save();
                }
            }
        }
    }
}
