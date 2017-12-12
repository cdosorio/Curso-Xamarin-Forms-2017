using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld._06_Navigation
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Toolbar : ContentPage
	{
		public Toolbar ()
		{
			InitializeComponent ();
		}

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            DisplayAlert("Activated", "ToolbarItem activated", "OK");
        }
    }
}