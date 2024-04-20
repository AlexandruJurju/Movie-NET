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
        var movie = _movieService.GetMovieById(movieId);
        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public IActionResult Post([FromBody] Movie movie)
    {
        var createdMovie = _movieService.SaveMovie(movie);
        return CreatedAtAction(nameof(Post), new { id = createdMovie.Id }, createdMovie);
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

        _movieService.DeleteMovie(movieId);
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

        _movieService.UpdateMovie(movieId, updatedMovie);
        return Ok();
    }

    [HttpPost("{movieId}/genres/{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult AddGenreToMovie([FromRoute] int movieId, [FromRoute] int genreId)
    {
        var movie = _movieService.GetMovieById(movieId);
        if (movie == null)
        {
            return NotFound();
        }


        _movieService.AddGenreToMovie(movieId, genreId);
        return Ok();
    }

    [HttpGet("{movieId}/genres")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
    [ProducesResponseType(400)]
    public IActionResult GetGenresByMovie([FromRoute] int movieId)
    {
        var genres = _movieService.GetGenresOfMovie(movieId);
        if (genres == null)
        {
            return NotFound();
        }

        return Ok(genres);
    }

    [HttpDelete("{movieId}/genres/{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult RemoveGenreFromMovie([FromRoute] int movieId, [FromRoute] int genreId)
    {
        var movie = _movieService.GetMovieById(movieId);
        if (movie == null)
        {
            return NotFound($"Movie with id {movieId} not found.");
        }

        _movieService.RemoveGenreFromMovie(movieId, genreId);
        return Ok();
    }
}