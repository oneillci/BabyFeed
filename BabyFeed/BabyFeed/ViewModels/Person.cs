using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace BubblingLabs.BabyFeed.ViewModel
{
    public class Person : PropertyChangedBase
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        public string GivenNames { get; set; }

        public string FamilyName { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", GivenNames, FamilyName);
            }
        }
    }
}
