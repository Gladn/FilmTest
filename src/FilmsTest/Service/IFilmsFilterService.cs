using AutoMapper;
using FilmsTest.DTOs;
using FilmsTest.Model.DBContext;
using Microsoft.EntityFrameworkCore;

namespace FilmsTest.Service
{
    public interface IFilmsFilterService
    {
        IEnumerable<FilmDTO> FilterFilms(string titleFilter, GenreDTO selectedGenre, string actorFilter);
    }


    public class FilmsFilterService : IFilmsFilterService
    {
        private readonly IMapper _mapper;

        public FilmsFilterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<FilmDTO> FilterFilms(string titleFilter, GenreDTO? selectedGenre, string actorFilter)
        {
            using (var context = new ApplicationContext())
            {
                var sqlQuery = "SELECT DISTINCT Films.* FROM Films " +
                               "JOIN FilmGenres ON Films.FmID = FilmGenres.FmID " +
                               "JOIN Genres ON FilmGenres.GenID = Genres.GenID " +
                               "JOIN FilmActors ON Films.FmID = FilmActors.FmID " +
                               "JOIN Actors ON FilmActors.ActID = Actors.ActID " +
                               "WHERE 1=1 "; 

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
                return _mapper.Map<IEnumerable<FilmDTO>>(films);
            }
        }
    }
}