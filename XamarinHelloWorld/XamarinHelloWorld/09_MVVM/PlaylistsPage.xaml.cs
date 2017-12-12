using MvvmDemo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHelloWorld.ViewModels;

namespace XamarinHelloWorld._09_MVVM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaylistsPage : ContentPage
    {
        // Move of the logic outside of this class (to the viewmodel)
        //Tip: no deberían quedar x:name, a menos que se usara dentro del mismo XAML.


        public PlaylistsPage()
        {
            myViewModel = new PlaylistsViewModel(new PageService()); // esto se puede reemplazar con DI
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //myViewModel.LoadPlaylistsCommand.Execute(); por ejemplo para cargar data desde un WS
            base.OnAppearing();
        }
               
        void OnPlaylistSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            myViewModel.SelectPlaylistCommand.Execute(e.SelectedItem);
           
        }

        private PlaylistsViewModel myViewModel
        {
            get { return BindingContext as PlaylistsViewModel; }
            set { BindingContext = value; }
        }

    }
}