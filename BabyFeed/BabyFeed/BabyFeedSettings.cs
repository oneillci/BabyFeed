using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;

namespace BubblingLabs.BabyFeed
{
    public class BabyFeedSettings
    {
        private const Gender GenderDefault = Gender.Boy;
        private const int FeedIntervalDefault = 3;
        private const bool ReminderDefault = true;
        private DateTime DayStartTimeDefault = new DateTime(2013, 1, 1, 0, 0, 0);

        public Gender Gender
        {
            get { return GetSetting<Gender>("gender"); }
            set { UpdateSetting("gender", value); }
        }

        public int FeedInterval 
        {
            get { return GetSetting<int>("feedinterval"); }
            set { UpdateSetting("feedinterval", value); }
        }

        public bool Reminder
        {
            get { return GetSetting<bool>("reminder"); }
            set { UpdateSetting("reminder", value); }
        }
        public DateTime DayStartTime
        {
            get { return GetSetting<DateTime>("starttime"); }
            set { UpdateSetting("starttime", value); }
        }

        public BabyFeedSettings()
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains("gender")) settings.Add("gender", GenderDefault);
            if (!settings.Contains("feedinterval")) settings.Add("feedinterval", FeedIntervalDefault);
            if (!settings.Contains("reminder")) settings.Add("reminder", ReminderDefault);
            if (!settings.Contains("starttime")) settings.Add("starttime", DayStartTimeDefault);
            settings.Save();
        }

        private T GetSetting<T>(string key)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            return (T)settings[key];
        }

        private void UpdateSetting<T>(string key, T newValue)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            settings[key] = newValue;
            settings.Save();
        }
    }

    public enum Gender
    {
        Boy, Girl
    }
}
