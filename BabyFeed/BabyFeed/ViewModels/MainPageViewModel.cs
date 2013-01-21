using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;

namespace BubblingLabs.BabyFeed.ViewModels
{
    public class MainPageViewModel : Screen
    {
        private readonly BabyFeedSettings settings;
        private const string BabyFeedReminderName = "BubblingLabs.BabyFeedReminder";

        public DateTime FeedTime { get; set; }

        public DateTime NextFeedTime { get { return FeedTime.AddHours(settings.FeedInterval); } }

        public bool SetReminder { get; set; }
        public int FeedCount { get; set; }

        public List<Feed> Feeds { get; set; }

        public MainPageViewModel(BabyFeedSettings babyFeedSettings)
        {
            settings = babyFeedSettings;
            Feeds = new List<Feed>(); // todo: get from IsolatedStorage
            FeedTime = DateTime.Now;
            SetReminder = settings.Reminder;
        }

        public void Save()
        {
            Feeds.Add(new Feed
            {
                FeedTime = this.FeedTime,
                Side = Side.Irrelevant
            });

            FeedCount = Feeds.Count;
            UpdateTileBackground();
            if (SetReminder)
                AddReminder();
        }

        private void AddReminder()
        {
            FeedTime  = DateTime.Now.AddSeconds(30);

            var oldReminder = ScheduledActionService.Find(BabyFeedReminderName);
            if (oldReminder != null)
                ScheduledActionService.Remove(oldReminder.Name);

            var reminder = new Reminder(BabyFeedReminderName)
            {
                BeginTime = NextFeedTime,
                Title = "BabyFeed",
                Content = "Time to feed the baby!"
            };
            ScheduledActionService.Add(reminder);
        }

        private void UpdateTileBackground()
        {
            var tile = ShellTile.ActiveTiles.First();
            var newData = new StandardTileData()
            {
                BackContent = "Next feed at " + NextFeedTime.ToShortTimeString()
            };
            tile.Update(newData);
        }
    }

    public class Feed
    {
        public DateTime FeedTime { get; set; }
        public Side Side { get; set; }
    }

    public enum Side
    {
    	Irrelevant,
        Left,
        Right
    }
}
