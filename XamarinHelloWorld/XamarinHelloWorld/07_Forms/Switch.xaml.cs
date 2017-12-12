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
    public partial class Switch : ContentPage
    {
        public Switch()
        {
            InitializeComponent();
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            lbl01.IsVisible = e.Value;
        }
    }
}