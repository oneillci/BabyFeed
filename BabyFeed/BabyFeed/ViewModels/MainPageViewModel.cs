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

        public MainPageViewModel()
        {
            FeedTime = DateTime.Now;
            NextFeedTime = FeedTime.AddHours(3);
            SetReminder = true;
        }

        public void Save()
        {
            FeedCount++;
            //MessageBox.Show(string.Format("Time: {0}", FeedTime.ToString()));
        }
    }
}
