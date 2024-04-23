using FluentResults;
using Microsoft.EntityFrameworkCore;
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

    public IEnumerable<Movie> FindAllMovies()
    {
        return _appDbContext.Movies.ToList();
    }

    public Result<Movie> FindMovieById(int movieId)
    {
        var movie = _appDbContext.Movies.FirstOrDefault(m => m.Id == movieId);

        if (movie == null)
        {
            return Result.Fail($"Movie with movieId {movieId} not found");
        }

        return Result.Ok(movie);
    }

    public Result DeleteMovie(int movieId)
    {
        var movie = _appDbContext.Movies.FirstOrDefault(m => m.Id == movieId);
        if (movie == null)
        {
            return Result.Fail($"Movie with movieId {movieId} not found");
        }

        _appDbContext.Movies.Remove(movie);
        _appDbContext.SaveChanges();
        return Result.Ok();
    }

    public Result UpdateMovie(int movieId, Movie updatedMovie)
    {
        var movie = _appDbContext.Movies.FirstOrDefault(m => m.Id == movieId);
        if (movie == null)
        {
            return Result.Fail($"Movie with movieId {movieId} not found");
        }

        var existingMovie = movie;
        existingMovie.Title = updatedMovie.Title;
        existingMovie.Headline = updatedMovie.Headline;
        existingMovie.Overview = updatedMovie.Overview;
        existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
        existingMovie.PosterUrl = updatedMovie.PosterUrl;

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
        var movie = _appDbContext.Movies.FirstOrDefault(m => m.Id == movieId);
        if (movie == null)
        {
            return Result.Fail($"Movie with id {movieId} not found");
        }

        var genre = _appDbContext.Genres.FirstOrDefault(g => g.Id == genreId);
        if (genre == null)
        {
            return Result.Fail($"Genre with id {genreId} not found");
        }

        movie.Genres.Add(genre);
        _appDbContext.Movies.Update(movie);
        _appDbContext.SaveChanges();

        return Result.Ok();
    }

    public Result<ICollection<Genre>> GetGenresOfMovie(int movieId)
    {
        var movie = _appDbContext.Movies
            .Include(movie => movie.Genres)
            .FirstOrDefault(m => m.Id == movieId);

        if (movie == null)
        {
            return Result.Fail($"Movie with id {movieId} not found");
        }

        return Result.Ok(movie.Genres);
    }

    public Result RemoveGenreFromMovie(int movieId, int genreId)
    {
        var movie = _appDbContext.Movies.FirstOrDefault(m => m.Id == movieId);
        if (movie == null)
        {
            return Result.Fail($"Movie with id {movieId} not found");
        }

        var genre = _appDbContext.Genres.FirstOrDefault(g => g.Id == genreId);
        if (genre == null)
        {
            return Result.Fail($"Genre with id {genreId} not found");
        }

        movie.Genres.Remove(genre);
        _appDbContext.Movies.Update(movie);
        _appDbContext.SaveChanges();

        return Result.Ok();
    }

    public Result<IEnumerable<MovieActor>> GetActorsOfMovie(int movieId)
    {
        var movie = _appDbContext.Movies
            .Include(movie => movie.MovieActors)
            .FirstOrDefault(m => m.Id == movieId);

        if (movie == null)
        {
            return Result.Fail($"Movie not found for result {movieId}");
        }

        var movieActors = movie.MovieActors.ToList();
        return Result.Ok<IEnumerable<MovieActor>>(movieActors);
    }

    public Result RemoveActorFromMovie(int movieId, int actorId)
    {
        var movie = _appDbContext.Movies
            .Include(movie => movie.MovieActors)
            .FirstOrDefault(m => m.Id == movieId);

        if (movie == null)
        {
            return Result.Fail("Movie not found for id {movieId}");
        }

        var genre = _appDbContext.Actors.FirstOrDefault(a => a.Id == actorId);
        if (genre == null)
        {
            return Result.Fail("Actor not found");
        }

        var movieActor = movie.MovieActors.FirstOrDefault(ma => ma.ActorId == actorId);
        if (movieActor == null)
        {
            return Result.Fail("Actor is not in this movie");
        }

        movie.MovieActors.Remove(movieActor);
        _appDbContext.SaveChanges();

        return Result.Ok();
    }

    public Result AddActorToMovie(MovieActor movieActor)
    {
        var movie = _appDbContext.Movies.FirstOrDefault(m => m.Id == movieActor.MovieId);
        if (movie == null)
        {
            return Result.Fail($"Movie not found for id {movieActor.MovieId}");
        }

        var actor = _appDbContext.Actors.FirstOrDefault(a => a.Id == movieActor.ActorId);
        if (actor == null)
        {
            return Result.Fail($"Actor not found for id {movieActor.ActorId}");
        }

        movie.MovieActors.Add(movieActor);
        _appDbContext.SaveChanges();

        return Result.Ok();
    }
}