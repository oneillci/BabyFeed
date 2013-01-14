using System;
using System.Collections.Generic;
using System.Linq;
using BubblingLabs.BabyFeed.ViewModels;
using Caliburn.Micro;
using Microsoft.Phone.Controls;

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
            //Conventions for Toolkit controls
            //http://compiledexperience.com/blog/posts/caliburn-micro-conventions-for-windows-phone
            ConventionManager.AddElementConvention<ToggleSwitch>(ToggleSwitch.IsCheckedProperty, "IsChecked", "Checked");

            //AddToggleSwitchConvention();
        }

        private static void AddToggleSwitchConvention()
        {           
        //    var cv = ConventionManager.AddElementConvention<ToggleSwitch>(
        //        ToggleSwitch.IsCheckedProperty,
        //        "IsChecked",
        //        "Click");
        //    cv.ApplyBinding = (viewModelType, path, property, element, convention) =>
        //{
        //    if (!ConventionManager.SetBinding(viewModelType, path, property, element, convention))
        //        return false;

        //    if (ConventionManager.HasBinding(element, ToggleSwitch.ContentProperty)) return true;

        //    var binding = new Binding(path + "Content") { Mode = BindingMode.TwoWay };
        //    BindingOperations.SetBinding(element, ToggleSwitch.ContentProperty, binding);

        //    return true;
        //};

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
