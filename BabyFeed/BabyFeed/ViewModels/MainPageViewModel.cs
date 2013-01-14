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

        public MainPageViewModel()
        {
            FeedTime = DateTime.Now;
        }

        public void Save()
        {
            MessageBox.Show("Saving");
        }
    }
}
