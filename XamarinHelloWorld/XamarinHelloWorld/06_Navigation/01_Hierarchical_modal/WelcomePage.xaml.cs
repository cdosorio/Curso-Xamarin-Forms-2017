using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld._06_Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }
                
        async private void btnNext_Clicked(object sender, EventArgs e)
        {
            // Hierarchical Navigation
            //await Navigation.PushAsync(new IntroductionPage());

            //Modal Pages
            await Navigation.PushModalAsync(new IntroductionPage());
        }
    }
}