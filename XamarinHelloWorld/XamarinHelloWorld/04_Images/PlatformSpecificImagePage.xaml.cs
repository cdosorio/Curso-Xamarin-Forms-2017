using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld._04_Images
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlatformSpecificImagePage : ContentPage
    {
        public PlatformSpecificImagePage()
        {
            InitializeComponent();

            //var clockIcon = "";

            //switch (Device.RuntimePlatform)
            //{
            //    case Device.iOS:
            //        clockIcon = "clock.png";
            //        break;
            //    case Device.Android:
            //        clockIcon = "clock.png";
            //        break;
            //}

            //btn.Image = (FileImageSource)ImageSource.FromFile(clockIcon);
        }
    }
}