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
	public partial class ImageEmbeddedPage : ContentPage
	{
		public ImageEmbeddedPage()
		{
			InitializeComponent ();
            
           // _image.Source = ImageSource.FromResource("XamarinHelloWorld.Images.cyberpunk.jpg");

            //Lo haremos declarativamente con la extensión EmbedededImage.

           
		}
	}
}