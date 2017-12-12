
using System;
using Xamarin.Forms;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld._06_Navigation
{
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(Contact contact)
        {  
            if (contact == null)
                throw new ArgumentNullException();

            BindingContext = contact;

            InitializeComponent();
        }

        public ContactDetailPage() {
            InitializeComponent();
        }

    }
}

