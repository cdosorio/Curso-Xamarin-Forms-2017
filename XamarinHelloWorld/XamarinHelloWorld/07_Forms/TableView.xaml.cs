using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld._07_Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableView : ContentPage
    {
        public TableView()
        {
            InitializeComponent();
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            //Para implementar Picker With Navigation
            var page = new PickerWithNavigation();

            //definir un manejo del evento
            page.ContactMethods.ItemSelected += (source, args) => //Lambda expression
            {
                contactMethod.Text = args.SelectedItem.ToString();
                Navigation.PopAsync(); //volver a pagina principal
            };

            Navigation.PushAsync(page);

        }
    }
}