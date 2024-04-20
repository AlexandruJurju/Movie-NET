using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interfaces;

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
    [ProducesResponseType(200,Type=typeof(IEnumerable<Movie>))]
    public IActionResult Get()
    {
        var movies = _movieService.GetAllMovies();
        return Ok(movies);
    }

    [HttpGet("{movieId}")]
    [ProducesResponseType(200,Type=typeof(Movie))]
    [ProducesResponseType(400)]
    public IActionResult Get([FromRoute] int movieId)
    {
        var movie = _movieService.GetMovieById(movieId);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
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
        var movie = _movieService.GetMovieById(movieId);

        if (movie == null)
        {
            return NotFound();
        }

        _movieService.DeleteMovie(movie);
        return Ok();
    }

    [HttpPut("{movieId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Update([FromRoute] int movieId, [FromBody] Movie updatedMovie)
    {
        var existingMovie = _movieService.GetMovieById(movieId);
        if (existingMovie == null)
        {
            return NotFound();
        }

        existingMovie.Title = updatedMovie.Title;
        existingMovie.Headline = updatedMovie.Headline;
        existingMovie.Overview = updatedMovie.Overview;
        existingMovie.ReleaseDate = updatedMovie.ReleaseDate;

        _movieService.UpdateMovie(existingMovie);

        return Ok();
    }
}