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
	public partial class ConfirmationBox : ContentPage
	{
		public ConfirmationBox ()
		{
			InitializeComponent ();
		}

        async void Button_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "esta seguro?", "Si", "No");
            if (response)
                DisplayAlert("Done", "your response will be saved", "ok");

            //...Si hubiera codigo a continuacion, que dependiera de la respuesta, seria necesario un await.

        }
    }
}