using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace BubblingLabs.BabyFeed.ViewModels
{
    public class SettingsViewModel : Screen
    {
        private readonly BabyFeedSettings settings;

        public Gender Gender
        {
            get { return settings.Gender; }
            set
            {
                settings.Gender = value;
                NotifyOfPropertyChange(() => Gender);
            }
        }

        public List<int> FeedIntervalList
        {
            get { return new List<int> { 2, 3, 4};}
        }

        public int FeedInterval
        {
            get { return settings.FeedInterval; }
            set
            {
                settings.FeedInterval = value;
                NotifyOfPropertyChange(() => FeedInterval);
            }
        }

        public bool Reminder
        {
            get { return settings.Reminder; }
            set
            {
                settings.Reminder = value;
                NotifyOfPropertyChange(() => Reminder);
            }
        }
        public DateTime DayStartTime
        {
            get { return settings.DayStartTime; }
            set
            {
                settings.DayStartTime = value;
                NotifyOfPropertyChange(() => DayStartTime);
            }
        }

        public SettingsViewModel(BabyFeedSettings settings)
        {
            this.settings = settings;
        }
    }
}
