using Movie_Net_Backend.Exceptions;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Repository.Interfaces;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
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
}
