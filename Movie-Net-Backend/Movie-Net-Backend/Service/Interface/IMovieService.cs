﻿using FluentResults;
using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interface;

public interface IMovieService
{
    IEnumerable<Movie> GetAllMovies();
    Result<Movie> GetMovieById(int movieId);
    Result DeleteMovie(int movieId);
    Result UpdateMovie(int movieId, Movie updatedMovie);
    Result<Movie> SaveMovie(Movie movie);
    Result AddGenreToMovie(int movieId, int genreId);
    Result<ICollection<Genre>> GetGenresOfMovie(int movieId);
    Result RemoveGenreFromMovie(int movieId, int genreId);
    Result<IEnumerable<Actor>> GetActorsOfMovie(int movieId);
    Result RemoveActorFromMovie(int movieId, int actorId);
    Result AddActorToMovie(MovieActor movieActor);
}