using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Caliburn.Micro;

namespace BubblingLabs.BabyFeed.ViewModels
{
    public class SettingsViewModel : Screen
    {
        private readonly BabyFeedSettings settings;

        public Gender Sex
        {
            get { return settings.Gender; }
            set
            {
                settings.Gender = value;
                NotifyOfPropertyChange(() => Sex);
                NotifyOfPropertyChange(() => BackgroundBrush);
            }
        }

        public IEnumerable<string> GenderList
        {
            get
            {
                // Todo replace this with localised resources
                return new [] { Gender.Boy.ToString(), Gender.Girl.ToString() };
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
}
