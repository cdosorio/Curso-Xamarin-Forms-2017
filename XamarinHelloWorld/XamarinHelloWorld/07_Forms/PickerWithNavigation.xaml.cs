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
    public partial class PickerWithNavigation : ContentPage
    {
        public PickerWithNavigation()
        {
            InitializeComponent();

            _listView.ItemsSource = new List<string>
            {
                "None",
                "Email",
                "SMS"
            };
        }

        public ListView ContactMethods { get { return _listView; } }
    }
}