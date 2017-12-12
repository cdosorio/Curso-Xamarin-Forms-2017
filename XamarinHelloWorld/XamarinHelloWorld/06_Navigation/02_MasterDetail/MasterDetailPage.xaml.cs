using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld._06_Navigation
{
	public partial class MastDetPage : MasterDetailPage
	{
		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
            var contact = e.SelectedItem as Contact;
            Detail = new NavigationPage( new ContactDetailPage(contact)); //usar el NavigationPage para que muestre boton volver.
            IsPresented = false; //deberia llamarse isMasterPresented
		}

		public MastDetPage()
		{
			InitializeComponent();

			listView.ItemsSource = new List<Contact> {
				new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1" },
				new Contact { Name = "John", ImageUrl = "http://lorempixel.com/100/100/people/2", Status = "Hey, let's talk!" }
			};
		}
	}
}

