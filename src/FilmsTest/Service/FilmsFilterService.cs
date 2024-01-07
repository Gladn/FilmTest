using FilmsTest.DTOs;
using FilmsTest.Model;
using FilmsTest.Model.DBContext;

namespace FilmsTest.Service
{
    public interface IFilmsFilterService
    {
        Task<IEnumerable<Film>> FilterFilms(string titleFilter, Genre? selectedGenre, string actorFilter);
    }


    public class FilmsFilterService : IFilmsFilterService
    {
        public async Task<IEnumerable<Film>> FilterFilms(string titleFilter, Genre? selectedGenre, string actorFilter)
        {
            using (var context = new ApplicationContext())
            {
                var query = from film in context.Films
                            join filmGenre in context.FilmGenres on film.FmID equals filmGenre.FmID
                            join genre in context.Genres on filmGenre.GenID equals genre.GenID
                            join filmActor in context.FilmActors on film.FmID equals filmActor.FmID
                            join actor in context.Actors on filmActor.ActID equals actor.ActID
                            select new { Film = film, Genre = genre, Actor = actor };

                if (!string.IsNullOrEmpty(titleFilter))
                {
                    query = query.Where(entry => entry.Film.FmTitle.Contains(titleFilter, StringComparison.OrdinalIgnoreCase));
                }

                if (selectedGenre != null && selectedGenre.GenID == -1)
                {
                    selectedGenre = null;
                }

                if (selectedGenre != null)
                {
                    query = query.Where(entry => entry.Genre.GenName == selectedGenre.GenName);
                }

                if (!string.IsNullOrEmpty(actorFilter))
                {
                    query = query.Where(entry => entry.Actor.ActName.Contains(actorFilter, StringComparison.OrdinalIgnoreCase));
                }

                return query.Select(entry => entry.Film).Distinct().ToList();
            }
        }
    }
}
