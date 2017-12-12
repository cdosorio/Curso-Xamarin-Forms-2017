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
	public partial class ActionSheet : ContentPage
	{
		public ActionSheet ()
		{
			InitializeComponent ();
		}

        async void Button_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayActionSheet("Seleccione", "Cancel", "Delete", "Copy","Send Email");
            await DisplayAlert("Su seleccion", response, "Ok");
           

            //...Si hubiera codigo a continuacion, que dependiera de la respuesta, seria necesario un await.

        }
    }
}