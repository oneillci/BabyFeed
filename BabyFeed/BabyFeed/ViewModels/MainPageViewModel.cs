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
        public string Name { get; set; }

        public bool CanSayHello
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        public void SayHello()
        {
            MessageBox.Show(string.Format("Hello {0}!", Name)); //Don't do this in real life :)
            Name = "test";
        }
    }
}
