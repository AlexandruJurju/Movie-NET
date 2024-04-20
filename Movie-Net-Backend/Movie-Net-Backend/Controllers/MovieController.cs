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
}