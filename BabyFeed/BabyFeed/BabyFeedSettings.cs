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
            get { return GetSetting<Gender>(GenderKey); }
            set { UpdateSetting(GenderKey, value); }
        }

        public int FeedInterval 
        {
            get { return GetSetting<int>(FeedIntervalKey); }
            set { UpdateSetting(FeedIntervalKey, value); }
        }

        public bool Reminder
        {
            get { return GetSetting<bool>(ReminderKey); }
            set { UpdateSetting(ReminderKey, value); }
        }
        public DateTime DayStartTime
        {
            get { return GetSetting<DateTime>(StartTimeKey); }
            set { UpdateSetting(StartTimeKey, value); }
        }

        private const string GenderKey = "gender";
        private const string FeedIntervalKey = "feedinterval";
        private const string ReminderKey = "reminder";
        private const string StartTimeKey = "starttime";

        public BabyFeedSettings()
        {
            // Set up defaults if they're not there
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (!settings.Contains(GenderKey)) settings.Add(GenderKey, GenderDefault);
            if (!settings.Contains(FeedIntervalKey)) settings.Add(FeedIntervalKey, FeedIntervalDefault);
            if (!settings.Contains(ReminderKey)) settings.Add(ReminderKey, ReminderDefault);
            if (!settings.Contains(StartTimeKey)) settings.Add(StartTimeKey, DayStartTimeDefault);
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
