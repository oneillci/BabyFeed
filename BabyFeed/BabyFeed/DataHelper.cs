using System;
using System.Collections.Generic;
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
        public List<Feed> GetTodaysFeeds()
        {
            try
            {
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (var reader = new StreamReader(store.OpenFile("today.xml", FileMode.OpenOrCreate)))
                    {
                        return JsonConvert.DeserializeObject<List<Feed>>(reader.ReadToEnd()) ?? new List<Feed>();
                    }
                }
            }
            catch (IsolatedStorageException exception)
            {
                return new List<Feed>();
            }
        }

        public void SaveTodayFeeds(List<Feed> feeds)
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
