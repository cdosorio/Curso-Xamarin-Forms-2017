using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GreetPage : ContentPage
    {
        public GreetPage()
        {
            InitializeComponent();
            slider1.Value = 0.5;

            //switch (Device.RuntimePlatform)
            //{
            //    case Device.iOS:
            //        Padding = new Thickness(0, 20, 0, 0);
            //        break;
            //    case Device.Android:
            //        Padding = new Thickness(0, 0, 0, 0);
            //        break;
            //    case Device.WinPhone:
            //        Padding = new Thickness(0, 0, 0, 0);
            //        break;                                   
            //}
                          
            
        }
                
    }
}