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
	public partial class SearchBar : ContentPage
	{
		public SearchBar()
		{
			InitializeComponent ();

            _list.ItemsSource = GetContacts();
        }

        private IEnumerable<Contact> GetContacts(string searchText = null)
        {
            var contacts = new List<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1" },
                new Contact { Name = "Michael", ImageUrl = "http://lorempixel.com/100/100/people/2" },
                new Contact { Name = "John", ImageUrl = "http://lorempixel.com/100/100/people/3", Status = "hey call me" },
                new Contact { Name = "Jimmy", ImageUrl = "http://lorempixel.com/100/100/people/4", Status = "hey call me" }
            };

            if (string.IsNullOrWhiteSpace(searchText))
                return contacts;

            var contacts2 = contacts.Where(c => c.Name.StartsWith(searchText, StringComparison.CurrentCultureIgnoreCase)); //where devuelve un IEnumerable

            return contacts2;
            
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _list.ItemsSource = GetContacts(e.NewTextValue);
           
        }
    }
}