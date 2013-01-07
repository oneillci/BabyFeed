using System;
using System.Collections.Generic;
using System.Linq;
using BubblingLabs.BabyFeed.ViewModels;
using Caliburn.Micro;

namespace BubblingLabs.BabyFeed
{
    public class BabyFeedBootstrapper : PhoneBootstrapper
    {
        PhoneContainer container;

        protected override void Configure()
        {
            container = new PhoneContainer(RootFrame);

            container.RegisterPhoneServices();
            container.PerRequest<MainPageViewModel>();
            //container.PerRequest<PivotPageViewModel>();
            //container.PerRequest<TabViewModel>();

            AddCustomConventions();  
        }

        static void AddCustomConventions()
        {
            //ellided  
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }  


    }
}
