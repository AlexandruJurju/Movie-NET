using FluentResults;
using Microsoft.EntityFrameworkCore;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Service;

public class MovieService(AppDbContext appDbContext) : IMovieService
{
    private readonly AppDbContext _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

    public async Task<IEnumerable<Movie>> FindAllMoviesAsync()
    {
        return await _appDbContext.Movies.ToListAsync();
    }

    public async Task<Result<Movie>> FindMovieByIdAsync(int movieId)
    {
        var movie = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

        if (movie == null) return Result.Fail($"Movie with movieId {movieId} not found");

        return Result.Ok(movie);
    }

    public async Task<Result> DeleteMovieAsync(int movieId)
    {
        var movie = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
        if (movie == null) return Result.Fail($"Movie with movieId {movieId} not found");

        _appDbContext.Movies.Remove(movie);
        await _appDbContext.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> UpdateMovieAsync(int movieId, Movie updatedMovie)
    {
        var movie = await _appDbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
        if (movie == null) return Result.Fail($"Movie with movieId {movieId} not found");

        var existingMovie = movie;
        existingMovie.Title = updatedMovie.Title;
        existingMovie.Headline = updatedMovie.Headline;
        existingMovie.Overview = updatedMovie.Overview;
        existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
        existingMovie.PosterUrl = updatedMovie.PosterUrl;

        _appDbContext.Movies.Update(existingMovie);
        await _appDbContext.SaveChangesAsync();
        return Result.Ok();
    }


    public async Task<Movie> SaveMovieAsync(Movie movie)
    {
        await _appDbContext.Movies.AddAsync(movie);
        await _appDbContext.SaveChangesAsync();
        return movie;
    }

    public async Task<List<Movie>> FindMoviesWithGenreAsync(int genreId)
    {
        var moviesWithGenre = await _appDbContext.Movies
            .Where(m => m.Genres.Any(g => g.Id == genreId))
            .ToListAsync();

        return (moviesWithGenre);
    }
}