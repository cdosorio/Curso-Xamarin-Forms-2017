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
	public partial class ImageExcercisePage : ContentPage
	{
        private int _currentImageId = 1;

        public ImageExcercisePage()
        {
            InitializeComponent();

            _currentImageId = 1;

            LoadImage();
        }

        void LoadImage()
        {
            _image.Source = new UriImageSource
            {
                Uri = new Uri(String.Format("http://lorempixel.com/1920/1080/city/{0}", _currentImageId)),
                CachingEnabled = false
            };
        }

        void Previous_Clicked(object sender, System.EventArgs e)
        {
            _currentImageId--;
            if (_currentImageId == 0)
                _currentImageId = 10;

            LoadImage();
        }

        void Next_Clicked(object sender, System.EventArgs e)
        {
            _currentImageId++;
            if (_currentImageId == 11)
                _currentImageId = 1;

            LoadImage();
        }
    }
}