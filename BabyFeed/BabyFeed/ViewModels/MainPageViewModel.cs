﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Caliburn.Micro;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;

namespace BubblingLabs.BabyFeed.ViewModels
{
    public class MainPageViewModel : Screen
    {
        private readonly BabyFeedSettings settings;
        private readonly DataHelper dataHelper;
        private readonly INavigationService navService;
        private const string BabyFeedReminderName = "BubblingLabs.BabyFeedReminder";
        public DateTime FeedTime { get; set; }
        public DateTime NextFeedTime { get { return FeedTime.AddHours(settings.FeedInterval); } }
        public bool SetReminder { get; set; }
        public int FeedCount { get { return Feeds.Count; } }
        public ObservableCollection<Feed> Feeds { get; set; }

        protected override void OnActivate()
        {
            NotifyOfPropertyChange(() => BackgroundBrush);
            NotifyOfPropertyChange(() => NextFeedTime);
        }

        public MainPageViewModel(BabyFeedSettings babyFeedSettings, DataHelper dataHelper, INavigationService navService)
        {
            settings = babyFeedSettings;
            this.dataHelper = dataHelper;
            this.navService = navService;
            Feeds = dataHelper.GetTodaysFeeds();
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

            dataHelper.SaveTodayFeeds(Feeds);

            NotifyOfPropertyChange(() => FeedCount);
            UpdateTileBackground();
            if (SetReminder)
                AddReminder();
        }

        public void Settings()
        {
            navService.UriFor<SettingsViewModel>().Navigate();
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

        public Brush BackgroundBrush
        {
            get
            {
                // todo: replace this with appropriate background image
                // http://cloford.com/resources/colours/500col.htm
                // Pink 1 & cobalt
                return settings.Gender == Gender.Boy 
                    ? new SolidColorBrush(Color.FromArgb(255, 61, 89, 171))
                : new SolidColorBrush(Color.FromArgb(255, 255, 181, 197));

                //return new LinearGradientBrush(new GradientStopCollection()
                //{
                //    new GradientStop() { Color = Colors.Black, Offset = 0 },
                //    settings.Gender == Gender.Boy
                //        ? new GradientStop() { Color = Colors.Blue, Offset = 1 }
                //        : new GradientStop() { Color = Colors.Red, Offset = 1 }

                //}, 90);
            }
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
