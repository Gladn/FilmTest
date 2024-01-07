using FilmsTest.Model;
using FilmsTest.Model.DBContext;
using Microsoft.EntityFrameworkCore;

namespace FilmsTest.Service
{
    public interface IFilmsFilterService
    {
        IEnumerable<Film> FilterFilms(string titleFilter, Genre? selectedGenre, string actorFilter);
    }


    public class FilmsFilterService : IFilmsFilterService
    {
        public IEnumerable<Film> FilterFilms(string titleFilter, Genre? selectedGenre, string actorFilter)
        {
            using (var context = new ApplicationContext())
            {
                var sqlQuery = "SELECT DISTINCT Films.* FROM Films " +
                       "JOIN FilmGenres ON Films.FmID = FilmGenres.FmID " +
                       "JOIN Genres ON FilmGenres.GenID = Genres.GenID " +
                       "JOIN FilmActors ON Films.FmID = FilmActors.FmID " +
                       "JOIN Actors ON FilmActors.ActID = Actors.ActID " ;

                if (selectedGenre != null && selectedGenre.GenID == -1)
                {
                    selectedGenre = null;
                }

                if (selectedGenre != null)
                {
                    sqlQuery += $"AND Genres.GenName = '{selectedGenre.GenName}' ";
                }

                if (!string.IsNullOrEmpty(titleFilter))
                {
                    sqlQuery += $"AND Films.FmTitle LIKE '%{titleFilter}%' ";
                }

                if (!string.IsNullOrEmpty(actorFilter))
                {
                    sqlQuery += $"AND Actors.ActName LIKE '%{actorFilter}%' ";
                }

                var films = context.Films.FromSqlRaw(sqlQuery).ToList();
                return films;
            }
        }
    }
}