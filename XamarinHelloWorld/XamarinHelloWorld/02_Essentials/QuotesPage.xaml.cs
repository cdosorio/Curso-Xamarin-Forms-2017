using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesPage : ContentPage
    {
        private string[] arrQuotes;
        private int idx;

        public QuotesPage()
        {
            InitializeComponent();

            arrQuotes = new string[] { "quote one", "quote two", "quote three" };
            idx = 0;
            lblQuote.Text = arrQuotes[0];
        }

        private void slider1_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblQuote.FontSize = e.NewValue;
        }

        private void btnNext_Clicked(object sender, EventArgs e)
        {
            idx += 1;
            if (idx > arrQuotes.Length)
            {
                idx = 0;
            }
            lblQuote.Text = arrQuotes[idx];
        }
    }
}