using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamarinHelloWorld
{
    public partial class App : Application
    {
        //definir los nombres de las properties de la App
        private const string TitleKey = "Title";
        private const string NotificationsEnabledKey = "NotificationsEnabled";

        public App()
        {
            InitializeComponent();

            //MainPage = new XamarinHelloWorld.GreetPage();
            MainPage = new NavigationPage(new _10_BeyondBasics.ResourceDictionary());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public string Title
        {
            get
            {
                if (Properties.ContainsKey(TitleKey))
                    return Properties[TitleKey].ToString();

                return "";
            }
            set
            {
                Properties[TitleKey] = value;
            }
        }

        public bool NotificationsEnabled
        {
            get
            {
                if (Properties.ContainsKey(NotificationsEnabledKey))
                    return (bool)Properties[NotificationsEnabledKey];

                return false;
            }
            set
            {
                Properties[NotificationsEnabledKey] = value;
            }
        }

    }
}
