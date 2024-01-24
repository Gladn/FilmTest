using FilmsTest.DTOs;
using System.Collections.ObjectModel;

namespace FilmsTest.Service
{
    public interface IFilmDetailsService
    {
        Task<Tuple<ObservableCollection<GenreDTO>, ObservableCollection<ActorDTO>>> ApplyFilmInfoFilterAsync(FilmDTO selectedFilm, ObservableCollection<GenreDTO> genresFiltered, ObservableCollection<ActorDTO> actorsFiltered);
    }


    public class FilmDetailsService : IFilmDetailsService
    {
        private readonly IDatabaseService _databaseService;

        public FilmDetailsService(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<Tuple<ObservableCollection<GenreDTO>, ObservableCollection<ActorDTO>>> ApplyFilmInfoFilterAsync(FilmDTO selectedFilm, ObservableCollection<GenreDTO> genresFiltered, ObservableCollection<ActorDTO> actorsFiltered)
        {
            if (genresFiltered == null)
            {
                genresFiltered = new ObservableCollection<GenreDTO>();
            }

            if (actorsFiltered == null)
            {
                actorsFiltered = new ObservableCollection<ActorDTO>();
            }

            var films = await _databaseService.GetFilmsAsync();
            var filmGenres = await _databaseService.GetFilmGenresAsync();
            var genres = await _databaseService.GetGenresAsync();
            var filmActors = await _databaseService.GetFilmActorsAsync();
            var actors = await _databaseService.GetActorsAsync();

            var query = from film in films
                        join filmGenre in filmGenres on film.FmID equals filmGenre.FmID
                        join genre in genres on filmGenre.GenID equals genre.GenID
                        join filmActor in filmActors on film.FmID equals filmActor.FmID
                        join actor in actors on filmActor.ActID equals actor.ActID
                        select new { Film = film, Genre = genre, Actor = actor };

            if (selectedFilm != null)
            {
                query = query.Where(entry => entry.Film.FmID == selectedFilm.FmID);
            }

            genresFiltered.Clear();
            actorsFiltered.Clear();

            foreach (var genre in query.Select(entry => entry.Genre).Distinct())
            {
                genresFiltered.Add(genre);
            }

            foreach (var actor in query.Select(entry => entry.Actor).Distinct())
            {
                actorsFiltered.Add(actor);
            }

            return Tuple.Create(genresFiltered, actorsFiltered);
        }
    }
}

