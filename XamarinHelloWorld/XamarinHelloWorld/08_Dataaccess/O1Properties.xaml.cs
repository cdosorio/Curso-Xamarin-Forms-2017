using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld._08_Dataaccess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class O1Properties : ContentPage
    {
       
        public O1Properties()
        {
            InitializeComponent();
            
            //El binding se encarga de mantener sincronizadas las proprerties con los controles de la página.
            BindingContext = Application.Current;

            var app = Application.Current as App;
            //title.Text = app.Title;
            //notificationsEnabled.On = app.NotificationsEnabled;
        }

        ////usar un solo metodo para todos los controles
        //private void OnChange(object sender, EventArgs e)
        //{
        //    var app = Application.Current as App;
        //   app.Title = title.Text;
        //   app.NotificationsEnabled = notificationsEnabled.On;

        //    //Para no tener que esperar a que la app vaya a sleep mode
        //    //Application.Current.SavePropertiesAsync();
        //}

        protected override void OnDisappearing()
        {
            //sirve cuando navego fuera la pagina.
            base.OnDisappearing();
        }

    }
}