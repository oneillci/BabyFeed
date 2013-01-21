using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using BubblingLabs.BabyFeed.ViewModels;
using System.IO;
using Newtonsoft.Json;

namespace BubblingLabs.BabyFeed
{
    public class DataHelper
    {
        public ObservableCollection<Feed> GetTodaysFeeds()
        {
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (var reader = new StreamReader(store.OpenFile("today.xml", FileMode.OpenOrCreate)))
                    {
                        return JsonConvert.DeserializeObject<ObservableCollection<Feed>>(reader.ReadToEnd()) 
                            ?? new ObservableCollection<Feed>();
                    }
                }
            }
            catch (IsolatedStorageException exception)
            {
                return new ObservableCollection<Feed>();
            }
        }

        public void SaveTodayFeeds(ObservableCollection<Feed> feeds)
        {
            string json = JsonConvert.SerializeObject(feeds);
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (var writer = new StreamWriter(store.OpenFile("today.xml", FileMode.OpenOrCreate)))
                    {                
                        writer.WriteLine(json);
                    }
                }
            }
            catch (IsolatedStorageException exception)
            {
            }
        }

    }
}
