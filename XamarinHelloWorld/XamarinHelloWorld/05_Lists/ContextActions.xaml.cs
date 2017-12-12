using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld._05_Lists
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContextActions : ContentPage
	{
        private ObservableCollection<Contact> _contacts;

        public ContextActions ()
        {
            InitializeComponent();

            _contacts  = GetContacts();
            _list.ItemsSource = _contacts;
        }

        private ObservableCollection<Contact> GetContacts()
        {
            return new ObservableCollection<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1" },
                new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/2", Status = "hey call me" }
            };
        }

        private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;

            DisplayAlert("Call", contact.Name, "OK");
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }

        private void _list_Refreshing(object sender, EventArgs e)
        {
            _list.ItemsSource = GetContacts();
            _list.EndRefresh();
        }
    }
}