using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinHelloWorld._08_Dataaccess
{
    //[Table("Recipes")]
    public class Recipe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _name; //backing field para fully implement del get y set.

        [MaxLength(255)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;

                _name = value;

                //levantar el evento UPDATED
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //Null conditional operator ? 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class O3_SQLite : ContentPage
    {
        //private fields
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes; //para que el listview se actualice

        public O3_SQLite()
        {
            InitializeComponent();

            //Similar al dbcontext del EF.
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        /// <summary>
        /// Dejar el constructor lo mas liviano posible
        /// </summary>
        protected override async void OnAppearing()
        {
            //Si no hay una tabla Recipe, esto la creará
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);
            recipesListView.ItemsSource = _recipes;

            base.OnAppearing();
        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };

            await _connection.InsertAsync(recipe);
            _recipes.Add(recipe);
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];
            recipe.Name += " Updated";
            await _connection.UpdateAsync(recipe);
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];
            await _connection.DeleteAsync(recipe);
            _recipes.Remove(recipe);
        }
    }
}