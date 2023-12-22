using FilmsTest.Model;
using FilmsTest.Model.DBContext;
using FilmsTest.Service;
using FilmsTest.View;
using FilmsTest.ViewModel.Command;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FilmsTest.ViewModel
{
    public class MainSearchViewModel : ViewModelBase
    {
        #region Свойства для доступа к данным в базе данных

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

       

        #region Команда первоначальной загрузки всей базы данных

        private bool _startUsingControls = false;
        public bool StartUsingControls
        {
            get => _startUsingControls;
            set => Set(ref _startUsingControls, value);
        }

        public ICommand CreateDatabaseCommand { get; }

        private bool CanCreateDatabaseCommandExecute(object? parameter) => true;
        private async Task OnCreateDatabaseCommandExecuted(object? parameter)
        {
            await CreateDatabase();
			StartUsingControls = true;
		}

        private async Task CreateDatabase()
        {
            try
            {
                using (var context = new ApplicationContext())
                {

                    await context.Database.EnsureCreatedAsync();



                    #region Дефолт информация Фильмы

                    if (!context.Films.Any())
                    {
                        var films = new List<Film>
                    {
                    new Film { FmID = 1, FmTitle = "Побег из Шоушенка", FmYear = 1994 },
                    new Film { FmID = 2, FmTitle = "Крёстный отец", FmYear = 1972 },
                    new Film { FmID = 3, FmTitle = "Тёмный рыцарь", FmYear = 2008 },
                    new Film { FmID = 4, FmTitle = "Крёстный отец 2", FmYear = 1974 },
                    new Film { FmID = 5, FmTitle = "12 разгневанных мужчин", FmYear = 1957 },
                    new Film { FmID = 6, FmTitle = "Список Шиндлера", FmYear = 1993 },
                    new Film { FmID = 7, FmTitle = "Властелин колец: Возвращение короля", FmYear = 2003 },
                    new Film { FmID = 8, FmTitle = "Криминальное чтиво", FmYear = 1994 },
                    new Film { FmID = 9, FmTitle = "Властелин колец: Братство Кольца", FmYear = 2001 },
                    new Film { FmID = 10, FmTitle = "Форрест Гамп", FmYear = 1994 },
                    new Film { FmID = 11, FmTitle = "Бойцовский клуб", FmYear = 1999 },
                    new Film { FmID = 12, FmTitle = "Властелин колец: Две крепости", FmYear = 2002 },
                    new Film { FmID = 13, FmTitle = "Новый фильм 13", FmYear = 2023 },
                    new Film { FmID = 14, FmTitle = "Новый фильм 14", FmYear = 2023 }
                    };

                        context.AddRange(films);
                        await context.SaveChangesAsync();
                    }
                    #endregion



                    #region Дефолт информация Жанры

                    if (!context.Genres.Any())
                    {
                        var genres = new List<Genre>
                    {
                        new Genre { GenID = 1, GenName = "драма" },
                        new Genre { GenID = 2, GenName = "детектив" },
                        new Genre { GenID = 3, GenName = "боевик" },
                        new Genre { GenID = 4, GenName = "биография" },
                        new Genre { GenID = 5, GenName = "исторический фильм" },
                        new Genre { GenID = 6, GenName = "приключение" },
                        new Genre { GenID = 7, GenName = "вестерн" },
                        new Genre { GenID = 8, GenName = "романтический фильм" },
                        new Genre { GenID = 9, GenName = "научная фантастика" },
                        new Genre { GenID = 10, GenName = "фэнтези" },
                        new Genre { GenID = 11, GenName = "Новый жанр 1" },
                        new Genre { GenID = -1, GenName = "Отмена" }
                    };

                        context.Genres.AddRange(genres);
                        await context.SaveChangesAsync();
                    }
                    #endregion                 



                    #region Дефолт информация Фильмы-Жанры

                    if (!context.FilmGenres.Any())
                    {
                        var filmGenres = new List<FilmGenre>
                        {
                            new FilmGenre { FmID = 1, GenID = 1 },
                            new FilmGenre { FmID = 2, GenID = 1 },
                            new FilmGenre { FmID = 2, GenID = 2 },
                            new FilmGenre { FmID = 3, GenID = 1 },
                            new FilmGenre { FmID = 3, GenID = 2 },
                            new FilmGenre { FmID = 3, GenID = 3 },
                            new FilmGenre { FmID = 4, GenID = 1 },
                            new FilmGenre { FmID = 4, GenID = 2 },
                            new FilmGenre { FmID = 5, GenID = 1 },
                            new FilmGenre { FmID = 5, GenID = 2 },
                            new FilmGenre { FmID = 6, GenID = 1 },
                            new FilmGenre { FmID = 6, GenID = 4 },
                            new FilmGenre { FmID = 6, GenID = 5 },
                            new FilmGenre { FmID = 7, GenID = 1 },
                            new FilmGenre { FmID = 7, GenID = 3 },
                            new FilmGenre { FmID = 7, GenID = 6 },
                            new FilmGenre { FmID = 7, GenID = 10 },
                            new FilmGenre { FmID = 8, GenID = 1 },
                            new FilmGenre { FmID = 8, GenID = 2 },
                            new FilmGenre { FmID = 9, GenID = 1 },
                            new FilmGenre { FmID = 9, GenID = 3 },
                            new FilmGenre { FmID = 9, GenID = 6 },
                            new FilmGenre { FmID = 9, GenID = 10 },
                            new FilmGenre { FmID = 10, GenID = 1 },
                            new FilmGenre { FmID = 10, GenID = 8 },
                            new FilmGenre { FmID = 11, GenID = 1 },
                            new FilmGenre { FmID = 12, GenID = 1 },
                            new FilmGenre { FmID = 12, GenID = 2 },
                            new FilmGenre { FmID = 12, GenID = 6 },
                            new FilmGenre { FmID = 12, GenID = 10 },
                            new FilmGenre { FmID = 13, GenID = 11 },
                            new FilmGenre { FmID = 13, GenID = 9 },
                            new FilmGenre { FmID = 13, GenID = 4 },
                            new FilmGenre { FmID = 13, GenID = 7 },
                            new FilmGenre { FmID = 13, GenID = 5 },
                            new FilmGenre { FmID = 13, GenID = 3 },
                            new FilmGenre { FmID = 13, GenID = 2 },
                            new FilmGenre { FmID = 14, GenID = 11 },
                            new FilmGenre { FmID = 14, GenID = 10 },
                            new FilmGenre { FmID = 14, GenID = 8 },
                            new FilmGenre { FmID = 14, GenID = 6 },
                            new FilmGenre { FmID = 14, GenID = 1 }
                        };

                        context.FilmGenres.AddRange(filmGenres);
                        await context.SaveChangesAsync();
                    }
                    #endregion



                    #region Дефолт информация Актеры

                    if (!context.Actors.Any())
                    {
                        var actors = new List<Actor>
                    {
                        new Actor { ActID = 1, ActName = "Тим Роббинс" },
                        new Actor { ActID = 2, ActName = "Морган Фримен" },
                        new Actor { ActID = 3, ActName = "Боб Гантон" },
                        new Actor { ActID = 4, ActName = "Марлон Брандо" },
                        new Actor { ActID = 5, ActName = "Аль Пачино" },
                        new Actor { ActID = 6, ActName = "Джеймс Каан" },
                        new Actor { ActID = 7, ActName = "Кристиан Бейл" },
                        new Actor { ActID = 8, ActName = "Хит Леджер" },
                        new Actor { ActID = 9, ActName = "Гэри Олдмен" },
                        new Actor { ActID = 10, ActName = "Мартин Болсам" },
                        new Actor { ActID = 11, ActName = "Джон Фидлер" },
                        new Actor { ActID = 12, ActName = "Ли Джей Кобб" },
                        new Actor { ActID = 13, ActName = "Лиам Нисон" },
                        new Actor { ActID = 14, ActName = "Бен Кингсли" },
                        new Actor { ActID = 15, ActName = "Рэйф Файнс" },
                        new Actor { ActID = 16, ActName = "Элайджа Вуд" },
                        new Actor { ActID = 17, ActName = "Вигго Мортенсен" },
                        new Actor { ActID = 18, ActName = "Шон Эстин" },
                        new Actor { ActID = 19, ActName = "Иэн Маккеллен" },
                        new Actor { ActID = 20, ActName = "Орландо Блум" },
                        new Actor { ActID = 21, ActName = "Джон Траволта" },
                        new Actor { ActID = 22, ActName = "Сэмюэл Л. Джексон" },
                        new Actor { ActID = 23, ActName = "Брюс Уиллис" },
                        new Actor { ActID = 24, ActName = "Эдвард Нортон" },
                        new Actor { ActID = 25, ActName = "Брэд Питт" },
                        new Actor { ActID = 26, ActName = "Хелена Бонэм Картер" },
                        new Actor { ActID = 27, ActName = "Джаред Лето" },
                        new Actor { ActID = 28, ActName = "Том Хэнкс" },
                        new Actor { ActID = 29, ActName = "Робин Райт" },
                        new Actor { ActID = 30, ActName = "Гэри Синиз" },
                        new Actor { ActID = 31, ActName = "Новый актер 31" },
                        new Actor { ActID = 32, ActName = "Новый актер 32" },
                        new Actor { ActID = 33, ActName = "Новый актер 33" }
                    };

                        context.Actors.AddRange(actors);
                        await context.SaveChangesAsync();
                    }
                    #endregion



                    #region Дефолт информация Фильмы-Актеры

                    if (!context.FilmActors.Any())
                    {
                        var filmActors = new List<FilmActor>
                        {
                            new FilmActor { FmID = 1, ActID = 1 },
                            new FilmActor { FmID = 1, ActID = 2 },
                            new FilmActor { FmID = 1, ActID = 3 },
                            new FilmActor { FmID = 2, ActID = 4 },
                            new FilmActor { FmID = 2, ActID = 5 },
                            new FilmActor { FmID = 2, ActID = 6 },
                            new FilmActor { FmID = 3, ActID = 7 },
                            new FilmActor { FmID = 3, ActID = 8 },
                            new FilmActor { FmID = 3, ActID = 9 },
                            new FilmActor { FmID = 4, ActID = 4 },
                            new FilmActor { FmID = 4, ActID = 5 },
                            new FilmActor { FmID = 4, ActID = 6 },
                            new FilmActor { FmID = 5, ActID = 10 },
                            new FilmActor { FmID = 5, ActID = 11 },
                            new FilmActor { FmID = 5, ActID = 12 },
                            new FilmActor { FmID = 6, ActID = 13 },
                            new FilmActor { FmID = 6, ActID = 14 },
                            new FilmActor { FmID = 6, ActID = 15 },
                            new FilmActor { FmID = 7, ActID = 16 },
                            new FilmActor { FmID = 7, ActID = 17 },
                            new FilmActor { FmID = 7, ActID = 18 },
                            new FilmActor { FmID = 7, ActID = 19 },
                            new FilmActor { FmID = 7, ActID = 20 },
                            new FilmActor { FmID = 8, ActID = 21 },
                            new FilmActor { FmID = 8, ActID = 22 },
                            new FilmActor { FmID = 8, ActID = 23 },
                            new FilmActor { FmID = 9, ActID = 16 },
                            new FilmActor { FmID = 9, ActID = 17 },
                            new FilmActor { FmID = 9, ActID = 18 },
                            new FilmActor { FmID = 9, ActID = 19 },
                            new FilmActor { FmID = 9, ActID = 20 },
                            new FilmActor { FmID = 10, ActID = 28 },
                            new FilmActor { FmID = 10, ActID = 29 },
                            new FilmActor { FmID = 10, ActID = 30 },
                            new FilmActor { FmID = 10, ActID = 27 },
                            new FilmActor { FmID = 11, ActID = 24 },
                            new FilmActor { FmID = 11, ActID = 25 },
                            new FilmActor { FmID = 11, ActID = 26 },
                            new FilmActor { FmID = 12, ActID = 16 },
                            new FilmActor { FmID = 12, ActID = 17 },
                            new FilmActor { FmID = 12, ActID = 18 },
                            new FilmActor { FmID = 12, ActID = 19 },
                            new FilmActor { FmID = 12, ActID = 20 },

                            new FilmActor { FmID = 13, ActID = 31 },
                            new FilmActor { FmID = 13, ActID = 32 },
                            new FilmActor { FmID = 13, ActID = 33 },
                            new FilmActor { FmID = 13, ActID = 29 },
                            new FilmActor { FmID = 13, ActID = 26 },
                            new FilmActor { FmID = 13, ActID = 22 },
                            new FilmActor { FmID = 13, ActID = 16 },
                            new FilmActor { FmID = 13, ActID = 10 },
                            new FilmActor { FmID = 13, ActID = 5 },

                            new FilmActor { FmID = 14, ActID = 31 },
                            new FilmActor { FmID = 14, ActID = 32 },
                            new FilmActor { FmID = 14, ActID = 33 },
                            new FilmActor { FmID = 14, ActID = 27 },
                            new FilmActor { FmID = 14, ActID = 21 },
                            new FilmActor { FmID = 14, ActID = 14 },
                            new FilmActor { FmID = 14, ActID = 9 },
                            new FilmActor { FmID = 14, ActID = 2 },
                        };

                        context.FilmActors.AddRange(filmActors);
                        await context.SaveChangesAsync();
                    }
                    #endregion



                    Films = new ObservableCollection<Film>(await context.Films.ToListAsync());
                    FilmsFiltered = new ObservableCollection<Film>(Films);
                    Genres = new ObservableCollection<Genre>(await context.Genres.ToListAsync());
                    FilmGenres = new ObservableCollection<FilmGenre>(await context.FilmGenres.ToListAsync());
                    Actors = new ObservableCollection<Actor>(await context.Actors.ToListAsync());
                    FilmActors = new ObservableCollection<FilmActor>(await context.FilmActors.ToListAsync());
                }
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.DisplayAlert("Уведомление", $"База данных не создана. Код ошибки: {ex.Message}", "OK");
                });
            }
        }

        #endregion



        #region Команда для загрузки/обновления

        public ICommand LoadFilmDataCommand { get; }
        private bool CanFilmDataLoadCommandExecute(object? parameter) => true;
        private async Task OnFilmDataLoadCommandExecuted(object? parameter)
        {
            await LoadFilmDataAsync();
        }

        public async Task LoadFilmDataAsync()
        {
            using (var context = new ApplicationContext())
            {
                Films = new ObservableCollection<Film>(await context.Films.ToListAsync());
                Genres = new ObservableCollection<Genre>(await context.Genres.ToListAsync());
                FilmGenres = new ObservableCollection<FilmGenre>(await context.FilmGenres.ToListAsync());
                Actors = new ObservableCollection<Actor>(await context.Actors.ToListAsync());
                FilmActors = new ObservableCollection<FilmActor>(await context.FilmActors.ToListAsync());
            }
        }

        #endregion



        #region Фильтрация фильмов по критериям

        private ObservableCollection<Film> _filmsFilter;
        public ObservableCollection<Film> FilmsFiltered
        {
            get => _filmsFilter;
            set => Set(ref _filmsFilter, value);
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

        private void ApplyFilter()
        {

            var query = from film in Films
                        join filmGenre in FilmGenres on film.FmID equals filmGenre.FmID
                        join genre in Genres on filmGenre.GenID equals genre.GenID
                        join filmActor in FilmActors on film.FmID equals filmActor.FmID
                        join actor in Actors on filmActor.ActID equals actor.ActID
                        select new { Film = film, Genre = genre, Actor = actor };

            if (!string.IsNullOrEmpty(FilmFilterTitle))
            {
                query = query.Where(entry => entry.Film.FmTitle.Contains(FilmFilterTitle, StringComparison.OrdinalIgnoreCase));
            }

            if (SelectedGenre != null && SelectedGenre.GenID == -1)
            {
                SelectedGenre = null;
            }

            if (SelectedGenre != null)
            {
                query = query.Where(entry => entry.Genre.GenName == SelectedGenre.GenName);
            }

            if (!string.IsNullOrEmpty(FilmFilterActor))
            {
                query = query.Where(entry => entry.Actor.ActName.Contains(FilmFilterActor, StringComparison.OrdinalIgnoreCase));
            }

            FilmsFiltered = new ObservableCollection<Film>(query.Select(entry => entry.Film).Distinct());
        }

        #endregion



        #region Команда для открытия страницы с актерами выбранного фильма  

        public ICommand GotoDetailFilmCommand { get; }
        private bool CanGotoDetailFilmCommandExecute(object? parameter) => true;
        private async Task OnGotoDetailFilmCommandExecuted(object? parameter)
        {
            await GotoDetailFilm(SelectedFilm, ActorsFiltered, GenresFiltered);
        }

        public async Task GotoDetailFilm(Film film, ObservableCollection<Actor> selectedFilmActors, ObservableCollection<Genre> selectedFilmGenres)
        {
            try
            {
                await Device.InvokeOnMainThreadAsync(() =>
                {
                    Application.Current.MainPage.Navigation.PushAsync(new FilmDetailsPage(new FilmDetailsViewModel(film, selectedFilmActors, selectedFilmGenres)));
                });
               
                //TODO Тут был DI

            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.DisplayAlert("Уведомление", $"Ошибка перехода. Код ошибки: {ex.Message}", "OK");
                });
            }

        }



        #region Актеры и жанры выбранного фильма для отображения        

        private ObservableCollection<Actor> _actorsFilter;
        public ObservableCollection<Actor> ActorsFiltered
        {
            get => _actorsFilter;
            set => Set(ref _actorsFilter, value);
        }

        private ObservableCollection<Genre> _genresFilter;
        public ObservableCollection<Genre> GenresFiltered
        {
            get => _genresFilter;
            set => Set(ref _genresFilter, value);
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
                        join filmGenre in FilmGenres on film.FmID equals filmGenre.FmID
                        join genre in Genres on filmGenre.GenID equals genre.GenID
                        join filmActor in FilmActors on film.FmID equals filmActor.FmID
                        join actor in Actors on filmActor.ActID equals actor.ActID
                        select new { Film = film, Genre = genre, Actor = actor };


            if (SelectedFilm != null)
            {
                query = query.Where(entry => entry.Film.FmID == SelectedFilm.FmID);
            }

            GenresFiltered = new ObservableCollection<Genre>(query.Select(entry => entry.Genre).Distinct());
            ActorsFiltered = new ObservableCollection<Actor>(query.Select(entry => entry.Actor).Distinct());
        }

        #endregion

        #endregion



        public MainSearchViewModel()
        {
            CreateDatabaseCommand = new RelayCommand(OnCreateDatabaseCommandExecuted, CanCreateDatabaseCommandExecute);

            LoadFilmDataCommand = new RelayCommand(OnFilmDataLoadCommandExecuted, CanFilmDataLoadCommandExecute);

            GotoDetailFilmCommand = new RelayCommand(OnGotoDetailFilmCommandExecuted, CanGotoDetailFilmCommandExecute);
        }
    }

}
