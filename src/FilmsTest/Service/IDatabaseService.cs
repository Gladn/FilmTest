using AutoMapper;
using FilmsTest.DTOs;
using FilmsTest.Model;
using FilmsTest.Model.DBContext;
using Microsoft.EntityFrameworkCore;

namespace FilmsTest.Service
{
    public interface IDatabaseService
    {
        Task CreateDatabaseAsync();

        Task<IEnumerable<FilmDTO>> GetFilmsAsync();
        Task<IEnumerable<GenreDTO>> GetGenresAsync();
        Task<IEnumerable<FilmGenreDTO>> GetFilmGenresAsync();
        Task<IEnumerable<ActorDTO>> GetActorsAsync();
        Task<IEnumerable<FilmActorDTO>> GetFilmActorsAsync();
    }


    public class DatabaseService : IDatabaseService
    {
        private readonly IMapper _mapper;

        public DatabaseService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task CreateDatabaseAsync()
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

                        await context.AddRangeAsync(films);
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

                        await context.Genres.AddRangeAsync(genres);
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

                        await context.FilmGenres.AddRangeAsync(filmGenres);
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

                        await context.Actors.AddRangeAsync(actors);
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

                        await context.FilmActors.AddRangeAsync(filmActors);
                        await context.SaveChangesAsync();
                    }
                    #endregion


                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Уведомление", $"База данных не создана. Код ошибки: {ex.Message}", "OK");
            }
        }



        public async Task<IEnumerable<FilmDTO>> GetFilmsAsync()
        {
            using (var context = new ApplicationContext())
            {
                //return await context.Films.ToListAsync();
                var films = await context.Films.ToListAsync();
                return _mapper.Map<IEnumerable<FilmDTO>>(films);
            }
        }

        public async Task<IEnumerable<GenreDTO>> GetGenresAsync()
        {
            using (var context = new ApplicationContext())
            {
                var genres = await context.Genres.ToListAsync();
                return _mapper.Map<IEnumerable<GenreDTO>>(genres);
            }
        }

        public async Task<IEnumerable<FilmGenreDTO>> GetFilmGenresAsync()
        {
            using (var context = new ApplicationContext())
            {
                var filmGenres = await context.FilmGenres.ToListAsync();
                return _mapper.Map<IEnumerable<FilmGenreDTO>>(filmGenres);
            }
        }

        public async Task<IEnumerable<ActorDTO>> GetActorsAsync()
        {
            using (var context = new ApplicationContext())
            {
                var actors = await context.Actors.ToListAsync();
                return _mapper.Map<IEnumerable<ActorDTO>>(actors);
            }
        }

        public async Task<IEnumerable<FilmActorDTO>> GetFilmActorsAsync()
        {
            using (var context = new ApplicationContext())
            {
                var filmActors = await context.FilmActors.ToListAsync();
                return _mapper.Map<IEnumerable<FilmActorDTO>>(filmActors);
            }
        }
    }
}
