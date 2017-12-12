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
    public partial class Textboxes : ContentPage
    {
        public Textboxes()
        {
            InitializeComponent();
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
           // _label.Text = "completed";
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            _label.Text = e.NewTextValue;
        }
    }
}