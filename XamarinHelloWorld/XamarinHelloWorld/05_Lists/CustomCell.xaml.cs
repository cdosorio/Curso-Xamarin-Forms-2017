using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld._05_Lists
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomCell : ContentPage
	{
		public CustomCell ()
		{
			InitializeComponent ();

            _list.ItemsSource = new List<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1" },
                new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/2", Status = "hey call me" }
            };
        }
	}
}