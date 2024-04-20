using Movie_Net_Backend.Exceptions;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Repository.Interfaces;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IGenreRepository _genreRepository;

    public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository)
    {
        _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        return _movieRepository.GetAllMovies();
    }

    public Movie GetMovieById(int id)
    {
        var movie = _movieRepository.GetMovieById(id);
        if (movie == null)
        {
            throw new MovieNotFoundException("Movie not found");
        }

        return movie;
    }

    public void DeleteMovie(int id)
    {
        var movie = GetMovieById(id);
        _movieRepository.DeleteMovie(movie);
    }

    public void UpdateMovie(int id, Movie updatedMovie)
    {
        var existingMovie = GetMovieById(id);
        existingMovie.Title = updatedMovie.Title;
        existingMovie.Headline = updatedMovie.Headline;
        existingMovie.Overview = updatedMovie.Overview;
        existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
        _movieRepository.UpdateMovie(existingMovie);
    }

    public void SaveMovie(Movie movie)
    {
        _movieRepository.SaveMovie(movie);
    }

    public void AddGenreToMovie(int movieId, int genreId)
    {
        var movie = _movieRepository.GetMovieById(movieId);
        var genre = _genreRepository.GetGenreById(genreId);

        if (movie == null)
        {
            throw new MovieNotFoundException($"Movie with id {movieId} not found");
        }

        if (genre == null)
        {
            throw new GenreNotFoundException($"Genre with id {genreId} not found");
        }

        if (movie.Genres == null)
        {
            movie.Genres = new List<Genre>();
        }

        movie.Genres.Add(genre);
        _movieRepository.UpdateMovie(movie);
    }

    public ICollection<Genre> GetGenresOfMovie(int movieId)
    {
        var movie = _movieRepository.GetMovieById(movieId);
        if (movie == null)
        {
            throw new MovieNotFoundException($"Movie with id {movieId} not found");
        }

        return _movieRepository.GetGenresOfMovie(movieId);
    }

    public void RemoveGenreFromMovie(int movieId, int genreId)
    {
        var movie = _movieRepository.GetMovieById(movieId);
        var genre = _genreRepository.GetGenreById(genreId);

        if (movie == null)
        {
            throw new MovieNotFoundException($"Movie with id {movieId} not found");
        }

        if (genre == null)
        {
            throw new GenreNotFoundException($"Genre with id {genreId} not found");
        }

        _movieRepository.RemoveGenreFromMovie(movie, genre);
    }
}