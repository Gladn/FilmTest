using FilmsTest.Model;
using FilmsTest.Model.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;


namespace FilmsTest.ViewModel
{
    public class FilmDetailsViewModel : ViewModelBase
    {
        #region Свойства Фильмов
        private ObservableCollection<Film> _film;
        public ObservableCollection<Film> Films
        {
            get => _film;
            set => Set(ref _film, value);
        }

        private ObservableCollection<FilmGenre> _filmGenre;
        public ObservableCollection<FilmGenre> FilmGenres
        {
            get => _filmGenre;
            set => Set(ref _filmGenre, value);
        }

        private ObservableCollection<Genre> _genre;
        public ObservableCollection<Genre> Genres
        {
            get => _genre;
            set => Set(ref _genre, value);
        }

        private ObservableCollection<FilmActor> _filmActor;
        public ObservableCollection<FilmActor> FilmActors
        {
            get => _filmActor;
            set => Set(ref _filmActor, value);
        }

        private ObservableCollection<Actor> _actor;
        public ObservableCollection<Actor> Actors
        {
            get => _actor;
            set => Set(ref _actor, value);
        }
        #endregion



        #region Актеры выбранного фильма        

        private bool _isFilmSelected = true;
        public bool IsFilmSelected
        {
            get => _isFilmSelected;
            set => Set(ref _isFilmSelected, value);
        }

        private ObservableCollection<Actor> _actorsFilter;
        public ObservableCollection<Actor> ActorsFilter
        {
            get => _actorsFilter;
            set => Set(ref _actorsFilter, value);
        }

        private Film _selectedFilm;
        public Film SelectedFilm
        {
            get => _selectedFilm;
            set
            {
                _selectedFilm = value;
                OnPropertyChanged(nameof(SelectedFilm));
                ApplyFilmInfoFilter();
            }
        }

        private void ApplyFilmInfoFilter()
        {
            var query = from film in Films
                        join filmActor in FilmActors on film.FmID equals filmActor.FmID
                        join actor in Actors on filmActor.ActID equals actor.ActID
                        select new { Film = film, Actor = actor };


            if (SelectedFilm != null)
            {
                query = query.Where(entry => entry.Film.FmID == SelectedFilm.FmID);
                IsFilmSelected = false;
            }
            else IsFilmSelected = true;

            ActorsFilter = new ObservableCollection<Actor>(query.Select(entry => entry.Actor).Distinct());
        }

        #endregion

        
        private void LoadFilmData()
        {
            using (var context = new ApplicationContext())
            {
                Films = new ObservableCollection<Film>(context.Films.ToList());
                Actors = new ObservableCollection<Actor>(context.Actors.ToList());
                FilmActors = new ObservableCollection<FilmActor>(context.FilmActors.ToList());
            }
        }

        public FilmDetailsViewModel()
        {
            LoadFilmData();
        }         
    }
}
