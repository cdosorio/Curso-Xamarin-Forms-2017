using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld._07_Forms
{
    public class ContactMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Picker : ContentPage
    {
        private IList<ContactMethod> _contactMethods;

        public Picker()
        {
            InitializeComponent();

            _contactMethods = GetConctactMethod();

            foreach (var method in _contactMethods)
                pickContactMethod.Items.Add(method.Name);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = pickContactMethod.Items[pickContactMethod.SelectedIndex];
            //para acceder al objeto seleccionado, a partir del nombre
            var contactMethod = _contactMethods.Single(cm => cm.Name == name);
            
            DisplayAlert("Su seleccion", String.Format("ID={0}, Name={1}", contactMethod.Id, contactMethod.Name), "OK");
        }

        private IList<ContactMethod> GetConctactMethod()
        {
            return new List<ContactMethod>
            {
                new ContactMethod { Id = 1, Name = "SMS"},
                new ContactMethod { Id = 2, Name = "Email"}
            };
        }
    }
}