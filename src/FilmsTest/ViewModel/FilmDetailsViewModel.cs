using FilmsTest.DTOs;
using System.Collections.ObjectModel;


namespace FilmsTest.ViewModel
{
    public class FilmDetailsViewModel : ViewModelBase
    {

        private FilmDTO _selectedFilm;
        public FilmDTO SelectedFilm
        {
            get => _selectedFilm;
            set => Set(ref _selectedFilm, value);
        }


        private ObservableCollection<ActorDTO> _selectedFilmActor;
        public ObservableCollection<ActorDTO> SelectedFilmActors
        {
            get => _selectedFilmActor;
            set => Set(ref _selectedFilmActor, value);
        }


        private ObservableCollection<GenreDTO> _selectedFilmGenre;
        public ObservableCollection<GenreDTO> SelectedFilmGenres
        {
            get => _selectedFilmGenre;
            set => Set(ref _selectedFilmGenre, value);
        }


        public FilmDetailsViewModel(FilmDTO selectedFilm, ObservableCollection<ActorDTO> selectedFilmActors, ObservableCollection<GenreDTO> selectedFilmGenres)
        {
            SelectedFilm = selectedFilm;

            SelectedFilmActors = selectedFilmActors;

            SelectedFilmGenres = selectedFilmGenres;
        }
    }
}