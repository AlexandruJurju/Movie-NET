using Movie_Net_Backend.Model;

namespace Movie_Net_Backend.Service.Interfaces;

public interface IMovieService
{
    IEnumerable<Movie> GetAllMovies();
    void SaveMovie(Movie movie);
}