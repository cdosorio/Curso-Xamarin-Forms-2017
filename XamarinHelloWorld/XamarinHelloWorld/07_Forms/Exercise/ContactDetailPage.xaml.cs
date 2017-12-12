
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld._07_Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        //EventHandler<Contact> is a delegate 
        public event EventHandler<ContactFull> ContactAdded;
        public event EventHandler<ContactFull> ContactUpdated;

        public ContactDetailPage()
        {
            InitializeComponent();
        }

        public ContactDetailPage(ContactFull contact)
        {
            // Note the use of nameof() operator in C# 6. 
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));
                      
            InitializeComponent();

            //crea un nuevo objeto para que no se pierdan los cambios si vuelve sin grabar.
            //Requiere los eventos para notificar cuando hay cambios.
            BindingContext = new ContactFull
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Phone = contact.Phone,
                Email = contact.Email,
                IsBlocked = contact.IsBlocked
            };
            
        }

        async void btnSave_Clicked(object sender, EventArgs e)
        {
            var contact = BindingContext as ContactFull;

            if (string.IsNullOrWhiteSpace(contact.FullName))
            {
                await DisplayAlert("Warning", "Complete el nombre y apellido", "Aceptar");
                return;
            }


            if (contact.Id == 0)
            {
                // This is just a temporary hack to differentiate between a
                // new and an existing Contact object. In the next section, 
                // we'll store these Contact objects in a database. So, they
                // will automaticlaly get an Id.
                contact.Id = 1;

                // This is null-conditional operator in C#. It is the same as:
                // 
                // if (ContactAdded != null)
                // 		ContactAdded(this, contact);
                //
                // Read my blog post for more details:
                // http://programmingwithmosh.com/csharp/csharp-6-features-that-help-you-write-cleaner-code/
                //
                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                ContactUpdated?.Invoke(this, contact);
            }

            await Navigation.PopAsync();
        }                

    }
}