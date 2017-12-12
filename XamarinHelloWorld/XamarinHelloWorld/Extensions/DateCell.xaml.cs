using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateCell : ViewCell
    {
        //Definir como bindable property --INICIO
        public static readonly BindableProperty LabelNameProperty =
            BindableProperty.Create("labelname", typeof(string), typeof(DateCell));
        
        public string labelname
        {
            get { return (string)GetValue(LabelNameProperty); }
            set { SetValue(LabelNameProperty, value); }
        }                
        //Definir como bindable property --FIN


        public DateCell()
        {
            InitializeComponent();

            BindingContext = this;

        }
    }
}