using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld._05_Lists
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contacts : ContentPage
    {
        public Contacts()
        {
            InitializeComponent();

            _list.ItemsSource = new List<Contact>
            {
                new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/1" },
                new Contact { Name = "Mosh", ImageUrl = "http://lorempixel.com/100/100/people/2", Status = "hey call me" }
            };
        }

        private void _list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            DisplayAlert("Tapped", contact.Name, "OK");
        }

        private void _list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //Se comporta igual al tapped. Con la diferencia de que colorea el fondo.

            //var contact = e.SelectedItem as Contact;
            //DisplayAlert("Selected", contact.Name, "OK");

            //Esto evita el selected
            _list.SelectedItem = null;
        }
    }
}