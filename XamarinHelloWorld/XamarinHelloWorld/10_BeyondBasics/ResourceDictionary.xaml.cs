using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld._10_BeyondBasics
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResourceDictionary : ContentPage
    {
        public ResourceDictionary()
        {
            InitializeComponent();

            //this.Resources = new ResourceDictionary();
            //this.Resources["borderRadius"] = 20;

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Resources["buttonBackgroundColor"] = Color.Pink;
        }
    }
}