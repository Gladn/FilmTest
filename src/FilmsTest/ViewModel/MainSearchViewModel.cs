using FilmsTest.DTOs;
using FilmsTest.Model;
using FilmsTest.Service;
using FilmsTest.View;
using FilmsTest.ViewModel.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;



namespace FilmsTest.ViewModel
{
    public class MainSearchViewModel : ViewModelBase
    {
        public ObservableCollection<FilmDTO> Films { get; } = new();
        public ObservableCollection<GenreDTO> Genres { get; } = new();
        public ObservableCollection<FilmGenreDTO> FilmGenres { get; } = new();
        public ObservableCollection<ActorDTO> Actors { get; } = new();
        public ObservableCollection<FilmActorDTO> FilmActors { get; } = new();


        private readonly IDatabaseService databaseService;
        private readonly IFilmsFilterService filmsfilterService;
        private readonly IFilmDetailsService filmDetailsService;


        public MainSearchViewModel(IDatabaseService databaseService, IFilmsFilterService filmsfilterService)
        {
            this.databaseService = databaseService;
            this.filmsfilterService = filmsfilterService;
            

            CreateDatabaseCommand = new RelayCommand(OnCreateDatabaseCommandExecuted, CanCreateDatabaseCommandExecute);

            GotoDetailFilmCommand = new RelayCommand(OnGotoDetailFilmCommandExecuted, CanGotoDetailFilmCommandExecute);
        }



        #region Команда загрузки всей базы данных

        private bool _startUsingSearchControls = false;
        public bool StartUsingSearchControls { get => _startUsingSearchControls; set => Set(ref _startUsingSearchControls, value); }

        private bool _turnOffDatabaseButton = true;
        public bool TurnOffDatabaseButton { get => _turnOffDatabaseButton; set => Set(ref _turnOffDatabaseButton, value); }

        public ICommand CreateDatabaseCommand { get; }

        private bool CanCreateDatabaseCommandExecute(object? parameter) => true;
        private async Task OnCreateDatabaseCommandExecuted(object? parameter)
        {
            StartUsingSearchControls = true;
            TurnOffDatabaseButton = false;

            await CreateDatabaseAsync();
        }
        
        private async Task CreateDatabaseAsync()
        {
            await databaseService.CreateDatabaseAsync();

            var films = await databaseService.GetFilmsAsync();
            foreach (var film in films)
                Films.Add(film);


            var genres = await databaseService.GetGenresAsync();
            foreach (var genre in genres)
                Genres.Add(genre);


            var filmgenres = await databaseService.GetFilmGenresAsync();
            foreach (var filmgenre in filmgenres)
                FilmGenres.Add(filmgenre);


            var actors = await databaseService.GetActorsAsync();
            foreach (var actor in actors)
                Actors.Add(actor);


            var filmactors = await databaseService.GetFilmActorsAsync();
            foreach (var filmactor in filmactors)
                FilmActors.Add(filmactor);

            FilmsFiltered = new ObservableCollection<FilmDTO>(Films);
        }

        #endregion




        #region Фильтрация фильмов по критериям

        private ObservableCollection<FilmDTO> filmsFiltered;
        public ObservableCollection<FilmDTO> FilmsFiltered
        {
            get => filmsFiltered;
            set => Set(ref filmsFiltered, value);
        }


        private async Task ApplyFilter()
        {
            //FilmsFiltered = new ObservableCollection<FilmDTO>(
            //    filmsfilterService.FilterFilms(FilmFilterTitle, SelectedGenre, FilmFilterActor)
            //);
        }

        private Genre? _selectedGenre;
        public Genre? SelectedGenre
        {
            get => _selectedGenre;
            set
            {
                _selectedGenre = value;
                OnPropertyChanged(nameof(SelectedGenre));
                ApplyFilter();
            }
        }


        private string? _filmFilterTitle;
        public string? FilmFilterTitle
        {
            get { return _filmFilterTitle; }
            set
            {
                _filmFilterTitle = value;
                OnPropertyChanged(nameof(FilmFilterTitle));
                ApplyFilter();
            }
        }


        private string? _filmFilterActor;
        public string? FilmFilterActor
        {
            get { return _filmFilterActor; }
            set
            {
                _filmFilterActor = value;
                OnPropertyChanged(nameof(FilmFilterActor));
                ApplyFilter();
            }
        }       

        #endregion




        #region Команда для открытия страницы с актерами выбранного фильма  

        public ICommand GotoDetailFilmCommand { get; }
        private bool CanGotoDetailFilmCommandExecute(object? parameter) => true;
        private async Task OnGotoDetailFilmCommandExecuted(object? parameter)
        {
            await GotoDetailFilm(SelectedFilm, ActorsFiltered, GenresFiltered);
        }

        public async Task GotoDetailFilm(FilmDTO film, ObservableCollection<ActorDTO> selectedFilmActors, ObservableCollection<GenreDTO> selectedFilmGenres)
        {
            try
            {
                var navigationService = new NavigationService();
                var filmDetailsPage = new FilmDetailsPage(new FilmDetailsViewModel(film, selectedFilmActors, selectedFilmGenres));

                await navigationService.NavigateToPage(filmDetailsPage);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Уведомление", $"Ошибка перехода. Код ошибки: {ex.Message}", "OK");         
            }
        }



        #region Актеры и жанры выбранного фильма для отображения        

        private ObservableCollection<ActorDTO> _actorsFilter;
        public ObservableCollection<ActorDTO> ActorsFiltered
        {
            get => _actorsFilter;
            set => Set(ref _actorsFilter, value);
        }

        private ObservableCollection<GenreDTO> _genresFilter;
        public ObservableCollection<GenreDTO> GenresFiltered
        {
            get => _genresFilter;
            set => Set(ref _genresFilter, value);
        }

        private FilmDTO _selectedFilm;
        public FilmDTO SelectedFilm
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
                        join filmGenre in FilmGenres on film.FmID equals filmGenre.FmID
                        join genre in Genres on filmGenre.GenID equals genre.GenID
                        join filmActor in FilmActors on film.FmID equals filmActor.FmID
                        join actor in Actors on filmActor.ActID equals actor.ActID
                        select new { Film = film, Genre = genre, Actor = actor };


            if (SelectedFilm != null)
            {
                query = query.Where(entry => entry.Film.FmID == SelectedFilm.FmID);
            }

            GenresFiltered = new ObservableCollection<GenreDTO>(query.Select(entry => entry.Genre).Distinct());
            ActorsFiltered = new ObservableCollection<ActorDTO>(query.Select(entry => entry.Actor).Distinct());
        }

        #endregion

        #endregion
    }
}
