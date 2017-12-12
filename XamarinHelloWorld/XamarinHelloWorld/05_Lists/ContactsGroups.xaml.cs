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
	public partial class ContactsGroups : ContentPage
	{
		public ContactsGroups ()
		{
			InitializeComponent ();

            _list.ItemsSource = new List<ContactGroup>
            {
                new ContactGroup("M","M"){
                    new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1" }
                },

                new ContactGroup("J", "J"){
                    new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/2", Status = "hey call me" }
                }                                
            };
        }
	}
}