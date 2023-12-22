using FilmsTest.Model;
using System.Collections.ObjectModel;


namespace FilmsTest.ViewModel
{
    public class FilmDetailsViewModel : ViewModelBase
    {
          
        private Film _selectedFilm;
        public Film SelectedFilm
        {
            get => _selectedFilm;
            set => Set(ref _selectedFilm, value);
        }


        private ObservableCollection<Actor> _selectedFilmActor;
        public ObservableCollection<Actor> SelectedFilmActors
        {
            get => _selectedFilmActor;
            set => Set(ref _selectedFilmActor, value);
        }


        private ObservableCollection<Genre> _selectedFilmGenre;
        public ObservableCollection<Genre> SelectedFilmGenres
        {
            get => _selectedFilmGenre;
            set => Set(ref _selectedFilmGenre, value);
        }


        public FilmDetailsViewModel(Film selectedFilm, ObservableCollection<Actor> selectedFilmActors, ObservableCollection<Genre> selectedFilmGenres)
        {
            SelectedFilm = selectedFilm;

            SelectedFilmActors = selectedFilmActors;

            SelectedFilmGenres = selectedFilmGenres;
        }         
    }
}
