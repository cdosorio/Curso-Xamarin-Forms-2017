using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHelloWorld.Models;

namespace XamarinHelloWorld._08_Dataaccess.ExcerciseSQLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        private ObservableCollection<ContactSQLite> _contacts;
        private SQLiteAsyncConnection _connection;
        private Boolean isDataLoaded;

        public ContactsPage()
        {
            InitializeComponent();

            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            //usar un flag para que se carge solo la primera vez...
            if (isDataLoaded)
                return;

            isDataLoaded = true;
            await LoadData();

            base.OnAppearing();
        }

        private async Task LoadData()
        {
            //await _connection.DropTableAsync<ContactSQLite>();

            //Si no hay una tabla, esto la creará
            await _connection.CreateTableAsync<ContactSQLite>();
                        
            var contacts = await _connection.Table<ContactSQLite>().ToListAsync();

            _contacts = new ObservableCollection<ContactSQLite>(contacts);
            //_contacts = GetContacts(); 
            //await _connection.ExecuteAsync("update sqlite_sequence set seq = ? where name = ?;", new object[] { 3, "ContactSQLite" });
            //await _connection.InsertAllAsync(_contacts);
            
            listView1.ItemsSource = _contacts;
        }

        private ObservableCollection<ContactSQLite> GetContacts()
        {
            return new ObservableCollection<ContactSQLite>
            {
                new ContactSQLite {Id=11, FirstName = "John", LastName = "Smith", Email = "john@smith.com", Phone = "1111", IsBlocked=false },
                new ContactSQLite {Id=21, FirstName = "Mary", LastName = "Johnson", Email = "mary@johnson.com", Phone = "2222" , IsBlocked=false}
            };
        }


        async void OnAddContact(object sender, System.EventArgs e)
        {
            var page = new ContactDetailPage(new ContactSQLite());

            // We can subscribe to the ContactAdded event using a lambda expression.
            // If you're not familiar with this syntax, watch my C# Advanced course. 
            page.ContactAdded += (source, contact) =>
            {
                // ContactAdded event is raised when the user taps the Done button.
                // Here, we get notified and add this contact to our 
                // ObservableCollection.
                _contacts.Add(contact);
            };

            await Navigation.PushAsync(page);
        }

        async void OnContactSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            // We need to check if SelectedItem is null because further below 
            // we de-select the selected item. This will raise another ItemSelected
            // event, so this method will be called straight away. If we don't
            // check for null here, we'll get a NullReferenceException.
            if (listView1.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as ContactSQLite;

            // We de-select the selected item, so when we come back to the Contacts
            // page we can tap it again and navigate to ContactDetail. 
            listView1.SelectedItem = null;

            var page = new ContactDetailPage(selectedContact);

            //subscribe to the ContactUpdated event
            page.ContactUpdated += (source, contact) =>
            {
                // When the target page raises ContactUpdated event, we get 
                // notified and update properties of the selected contact. 
                // Here we are dealing with a small class with only a few 
                // properties. If working with a larger class, you may want 
                // to look at AutoMapper, which is a convention-based mapping
                // tool. 
                selectedContact.Id = contact.Id;
                selectedContact.FirstName = contact.FirstName;
                selectedContact.LastName = contact.LastName;
                selectedContact.Phone = contact.Phone;
                selectedContact.Email = contact.Email;
                selectedContact.IsBlocked = contact.IsBlocked;
            };

            await Navigation.PushAsync(page);
        }

        async void OnDeleteContact(object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as ContactSQLite;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
            {
                //primero lo removemos del observable, para que se refresque de inmediato en pantalla
                _contacts.Remove(contact);

                await _connection.DeleteAsync(contact);
            }
        }
    }
}