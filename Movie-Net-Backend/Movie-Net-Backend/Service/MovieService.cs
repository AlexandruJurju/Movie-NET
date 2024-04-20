using FluentResults;
using Movie_Net_Backend.Data;
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

    public Result<Movie> GetMovieById(int id)
    {
        var movie = _appDbContext.Movies.FirstOrDefault(m => m.Id == id);

        if (movie == null)
        {
            return Result.Fail("Movie is null");
        }

        return Result.Ok(movie);
    }

    public Result DeleteMovie(int id)
    {
        var movieResult = GetMovieById(id);
        if (movieResult.IsFailed)
        {
            return movieResult.ToResult();
        }

        _appDbContext.Movies.Remove(movieResult.Value);
        _appDbContext.SaveChanges();
        return Result.Ok();
    }

    public Result UpdateMovie(int id, Movie updatedMovie)
    {
        var movieResult = GetMovieById(id);
        if (movieResult.IsFailed)
        {
            return movieResult.ToResult();
        }

        var existingMovie = movieResult.Value;
        existingMovie.Title = updatedMovie.Title;
        existingMovie.Headline = updatedMovie.Headline;
        existingMovie.Overview = updatedMovie.Overview;
        existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
        _appDbContext.Movies.Update(existingMovie);
        _appDbContext.SaveChanges();
        return Result.Ok();
    }

    public Result<Movie> SaveMovie(Movie movie)
    {
        _appDbContext.Movies.Add(movie);
        _appDbContext.SaveChanges();
        return Result.Ok(movie);
    }

    public Result AddGenreToMovie(int movieId, int genreId)
    {
        var movieResult = GetMovieById(movieId);
        var genre = _appDbContext.Genres.FirstOrDefault(g => g.Id == genreId);

        if (movieResult.IsFailed)
        {
            return movieResult.ToResult();
        }

        if (genre == null)
        {
            return Result.Fail(new Error($"Genre with id {genreId} not found"));
        }

        movieResult.Value.Genres.Add(genre);
        _appDbContext.Movies.Update(movieResult.Value);
        _appDbContext.SaveChanges();

        return Result.Ok();
    }

    public Result<ICollection<Genre>> GetGenresOfMovie(int movieId)
    {
        var movieResult = GetMovieById(movieId);

        if (movieResult.IsFailed)
        {
            return Result.Fail<ICollection<Genre>>(new Error("Movie not found"));
        }

        return Result.Ok(movieResult.Value.Genres);
    }

    public Result RemoveGenreFromMovie(int movieId, int genreId)
    {
        var movieResult = GetMovieById(movieId);
        var genre = _appDbContext.Genres.FirstOrDefault(g => g.Id == genreId);

        if (movieResult.IsFailed)
        {
            return movieResult.ToResult();
        }

        if (genre == null)
        {
            return Result.Fail(new Error($"Genre with id {genreId} not found"));
        }

        movieResult.Value.Genres.Remove(genre);
        _appDbContext.Movies.Update(movieResult.Value);
        _appDbContext.SaveChanges();

        return Result.Ok();
    }
}