using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Exceptions;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]
    public IActionResult Get()
    {
        var movies = _movieService.GetAllMovies();
        return Ok(movies);
    }

    [HttpGet("{movieId}")]
    [ProducesResponseType(200, Type = typeof(Movie))]
    [ProducesResponseType(400)]
    public IActionResult Get([FromRoute] int movieId)
    {
        try
        {
            var movie = _movieService.GetMovieById(movieId);
            return Ok(movie);
        }
        catch (MovieNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ProducesResponseType(200)]
    public IActionResult Post([FromBody] Movie movie)
    {
        _movieService.SaveMovie(movie);
        return Ok(movie);
    }

    [HttpDelete("{movieId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Delete([FromRoute] int movieId)
    {
        try
        {
            _movieService.DeleteMovie(movieId);
            return Ok();
        }
        catch (MovieNotFoundException)
        {
            return NotFound();
        }
    }


    [HttpPut("{movieId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Update([FromRoute] int movieId, [FromBody] Movie updatedMovie)
    {
        try
        {
            _movieService.UpdateMovie(movieId, updatedMovie);
            return Ok();
        }
        catch (MovieNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost("{movieId}/genres/{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult AddGenreToMovie([FromRoute] int movieId, [FromRoute] int genreId)
    {
        try
        {
            _movieService.AddGenreToMovie(movieId, genreId);
            return Ok();
        }
        catch (MovieNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("{movieId}/genres")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
    [ProducesResponseType(400)]
    public IActionResult GetGenresByMovie([FromRoute] int movieId)
    {
        try
        {
            var genres = _movieService.GetGenresOfMovie(movieId);
            return Ok(genres);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpDelete("{movieId}/genres/{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult RemoveGenreFromMovie([FromRoute] int movieId, [FromRoute] int genreId)
    {
        try
        {
            _movieService.RemoveGenreFromMovie(movieId, genreId);
            return Ok();
        }
        catch (MovieNotFoundException)
        {
            return NotFound($"Movie with id {movieId} not found.");
        }
        catch (GenreNotFoundException)
        {
            return NotFound($"Genre with id {genreId} not found.");
        }
    }
}