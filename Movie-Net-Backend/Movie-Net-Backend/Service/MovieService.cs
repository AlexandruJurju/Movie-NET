using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Exceptions;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class MovieService : IMovieService
{
    private readonly AppDbContext _appDbContext;

    public MovieService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        return _appDbContext.Movies.ToList();
    }

    public Movie GetMovieById(int id)
    {
        var movie = _appDbContext.Movies.FirstOrDefault(m => m.Id == id);
        if (movie == null)
        {
            throw new MovieNotFoundException("Movie not found");
        }

        return movie;
    }

    public void DeleteMovie(int id)
    {
        var movie = GetMovieById(id);
        _appDbContext.Movies.Remove(movie);
        _appDbContext.SaveChanges();
    }

    public void UpdateMovie(int id, Movie updatedMovie)
    {
        var existingMovie = GetMovieById(id);
        existingMovie.Title = updatedMovie.Title;
        existingMovie.Headline = updatedMovie.Headline;
        existingMovie.Overview = updatedMovie.Overview;
        existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
        _appDbContext.Movies.Update(existingMovie);
        _appDbContext.SaveChanges();
    }

    public Movie SaveMovie(Movie movie)
    {
        _appDbContext.Movies.Add(movie);
        _appDbContext.SaveChanges();
        return movie;
    }

    public void AddGenreToMovie(int movieId, int genreId)
    {
        var movie = GetMovieById(movieId);
        var genre = _appDbContext.Genres.FirstOrDefault(g => g.Id == genreId);

        if (movie == null)
        {
            throw new MovieNotFoundException($"Movie with id {movieId} not found");
        }

        if (genre == null)
        {
            throw new GenreNotFoundException($"Genre with id {genreId} not found");
        }

        movie.Genres.Add(genre);
        _appDbContext.Movies.Update(movie);
        _appDbContext.SaveChanges();
    }

    public ICollection<Genre> GetGenresOfMovie(int movieId)
    {
        var movie = _appDbContext.Movies
            .Include(m => m.Genres)
            .FirstOrDefault(m => m.Id == movieId);

        if (movie == null)
        {
            throw new MovieNotFoundException($"Movie with id {movieId} not found");
        }

        return movie.Genres;
    }

    public void RemoveGenreFromMovie(int movieId, int genreId)
    {
        // eager loading
        var movie = _appDbContext.Movies
            .Include(m => m.Genres)
            .FirstOrDefault(m => m.Id == movieId);
        
        var genre = _appDbContext.Genres.FirstOrDefault(g => g.Id == genreId);

        if (movie == null)
        {
            throw new MovieNotFoundException($"Movie with id {movieId} not found");
        }

        if (genre == null)
        {
            throw new GenreNotFoundException($"Genre with id {genreId} not found");
        }

        movie.Genres.Remove(genre);
        _appDbContext.Movies.Update(movie);
        _appDbContext.SaveChanges();
    }
}