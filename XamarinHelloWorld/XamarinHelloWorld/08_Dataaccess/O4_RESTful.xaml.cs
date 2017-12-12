using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinHelloWorld._08_Dataaccess
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class O4_RESTful : ContentPage
    {
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Post> _posts;


        public O4_RESTful()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var posts = JsonConvert.DeserializeObject<List<Post>>(content);
            _posts = new ObservableCollection<Post>(posts);
            postsListView.ItemsSource = _posts;

            base.OnAppearing();
        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            var post = new Post { Title = "Title " + DateTime.Now.Ticks };

            //Enviar al servicio REST
            var content = JsonConvert.SerializeObject(post);
            await _client.PostAsync(Url, new StringContent(content));

            //y también actualizar el Observable Collection.
            _posts.Insert(0, post);
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            var post = _posts[0];
            post.Title += " UPDATED";

            var content = JsonConvert.SerializeObject(post);
            await _client.PutAsync(Url + "/" + post.Id, new StringContent(content));

            //para que se refleje en la UI, necesaitamos implementar el evento propertyChanged como en el ejemplo con SQLite.
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var post = _posts[0];
            await _client.DeleteAsync(Url + "/" + post.Id);
            _posts.Remove(post);
        }
    }
}