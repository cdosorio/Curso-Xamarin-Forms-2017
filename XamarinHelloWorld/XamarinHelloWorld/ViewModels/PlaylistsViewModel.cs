using MvvmDemo;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinHelloWorld._09_MVVM;

namespace XamarinHelloWorld.ViewModels
{
    /// <summary>
    /// No references to xamarin here. 
    /// </summary>
    class PlaylistsViewModel : BaseViewModel
    {
        //por orden, primero
        //1) campos private
        //2) campos publicos
        //3) Constructor
        //4) metodos privados

        private PlaylistViewModel _selectedPlaylist;
        private readonly IPageService _pageService;

        public ObservableCollection<PlaylistViewModel> Playlists { get; private set; } = new ObservableCollection<PlaylistViewModel>();

        //para soportar databinding a esta propiedad, le creamos un private field y definimos get y set
        
        public PlaylistViewModel SelectedPlaylist
        {
            get { return _selectedPlaylist; }
            set { SetValue(ref _selectedPlaylist, value); }
        }

        //Commands
        public ICommand AddPlaylistCommand { get; private set; }
        public ICommand SelectPlaylistCommand { get; private set; }

        
        //ctor
        public PlaylistsViewModel(IPageService pageService)
        {
            _pageService = pageService;
            AddPlaylistCommand = new Command(AddPlaylist); //el metodo se pasa como action, sin parentesis.
            //aca usa otra implementación pq el method recibe parámetro, y además no es void
            SelectPlaylistCommand = new Command<PlaylistViewModel>(async vm => await SelectPlaylist(vm));
        }

        private void AddPlaylist()
        {
            var newPlaylist = "Playlist " + (Playlists.Count + 1);

            Playlists.Add(new PlaylistViewModel { Title = newPlaylist });
        }

        private async Task SelectPlaylist(PlaylistViewModel playlist)
        {
            if (playlist == null)
                return;
                        
            playlist.IsFavorite = !playlist.IsFavorite;

            SelectedPlaylist = null;

            await _pageService.PushAsync (new PlaylistDetailPage(playlist));
        }

       
    }
}
