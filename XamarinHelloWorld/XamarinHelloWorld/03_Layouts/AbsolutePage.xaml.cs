using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld._03_Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AbsolutePage : ContentPage
    {
        public AbsolutePage()
        {
            InitializeComponent();
        }
    }
}
//Width and height are what people usually expect.However, x and y are not as people are more used to "left" and "top". So you can write a converter to convert left percentage into x and top percentage into y:

//x = left / (1 - width)
//y = top / (1 - height)