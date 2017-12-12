using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld._08_Dataaccess.ExcerciseSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {        
        public event EventHandler<ContactSQLite> ContactAdded;
        public event EventHandler<ContactSQLite> ContactUpdated;

        private SQLiteAsyncConnection _connection;
                
        public ContactDetailPage(ContactSQLite contact)
        {
            // Note the use of nameof() operator in C# 6. 
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            //crea un nuevo objeto para que no se pierdan los cambios si vuelve sin grabar.
            //Requiere los eventos para notificar cuando hay cambios.
            BindingContext = new ContactSQLite
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
            var contact = BindingContext as ContactSQLite;

            if (string.IsNullOrWhiteSpace(contact.FullName))
            {
                await DisplayAlert("Warning", "Complete el nombre y apellido", "Aceptar");
                return;
            }


            if (contact.Id == 0)
            {
                //contact.Id = 1;
                await _connection.InsertAsync(contact);
                ContactAdded?.Invoke(this, contact);
            }
            else
            {
                await _connection.UpdateAsync(contact);
                ContactUpdated?.Invoke(this, contact);
            }

            await Navigation.PopAsync();
        }
    }
}