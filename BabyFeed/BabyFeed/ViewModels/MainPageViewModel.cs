using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace BubblingLabs.BabyFeed.ViewModels
{
    public class MainPageViewModel : Screen
    {
        public DateTime FeedTime { get; set; }
        public DateTime NextFeedTime { get; set; }
        public bool? SetReminder { get; set; }
        public int FeedCount { get; set; }

        public List<Feed> Feeds { get; set; }

        public MainPageViewModel()
        {
            Feeds = new List<Feed>(); // todo: get from IsolatedStorage
            FeedTime = DateTime.Now;
            NextFeedTime = FeedTime.AddHours(3);
            SetReminder = true;
        }

        public void Save()
        {
            Feeds.Add(new Feed
            {
                FeedTime = this.FeedTime,
                Side = Side.Irrelevant
            });

            FeedCount = Feeds.Count;
            if (SetReminder.Value)
                MessageBox.Show(string.Format("Time: {0}", FeedTime.ToString()));
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
