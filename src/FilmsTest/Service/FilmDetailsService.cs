using FilmsTest.Model;
using System.Collections.ObjectModel;

namespace FilmsTest.Service
{
    public interface IFilmDetailsService
    {
        void ApplyFilmInfoFilter(Film selectedFilm, ObservableCollection<Genre> genresFiltered, ObservableCollection<Actor> actorsFilter);
    }

    public class FilmDetailsService : IFilmDetailsService
    {
        private readonly ObservableCollection<Film> _films;
        private readonly ObservableCollection<Genre> _genres;
        private readonly ObservableCollection<Actor> _actors;
        private readonly ObservableCollection<FilmGenre> _filmGenres;
        private readonly ObservableCollection<FilmActor> _filmActors;

        public FilmDetailsService(
            ObservableCollection<Film> films,
            ObservableCollection<Genre> genres,
            ObservableCollection<Actor> actors,
            ObservableCollection<FilmGenre> filmGenres,
            ObservableCollection<FilmActor> filmActors)
        {
            _films = films;
            _genres = genres;
            _actors = actors;
            _filmGenres = filmGenres;
            _filmActors = filmActors;
        }

        public void ApplyFilmInfoFilter(Film selectedFilm, ObservableCollection<Genre> genresFiltered, ObservableCollection<Actor> actorsFiltered)
        {
            var query = from film in _films
                        join filmGenre in _filmGenres on film.FmID equals filmGenre.FmID
                        join genre in _genres on filmGenre.GenID equals genre.GenID
                        join filmActor in _filmActors on film.FmID equals filmActor.FmID
                        join actor in _actors on filmActor.ActID equals actor.ActID
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
        }
    }
}
