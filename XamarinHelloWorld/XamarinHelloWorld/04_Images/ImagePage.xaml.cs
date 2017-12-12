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
	public partial class ImagePage : ContentPage
	{
		public ImagePage ()
		{
			InitializeComponent ();

            Task.Delay(1000);
            
            var imageSource = new UriImageSource { Uri = new Uri("http://walldiskpaper.com/wp-content/uploads/2015/11/Digital-Astronaut-1920x1080-Wallpaper-Background.jpg") };
            imageSource.CachingEnabled = false; //default: True
            imageSource.CacheValidity = TimeSpan.FromHours(1); //default: guarda por 24 hrs
            
            _image.Source = imageSource;
            
		}
	}
}