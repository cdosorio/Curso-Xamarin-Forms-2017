namespace MvvmDemo
{
    //Problemas (hasta inicio de clase 100)
    //1) Playlist is a Domain class, BaseViewModel is a Presentation class => no deberia heredar de ella
    //2) in a Domain class como esta, no se deberia implementar INotifyPropertyChanged. Aunque sea una interfaz genérica, ya que solo se está usando para la UI.
    //3) La Color property solo es para UI. El domain solo debe usarse para representar el estado de la app. No debe saber nada de la UI.


    public class Playlist 
    {      
        public string Title { get; set; }

        private bool _isFavorite; 
        public bool IsFavorite { get; set; }
                       
    }
}
