using Microsoft.AspNetCore.Mvc;
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
        var moviesResult = _movieService.GetAllMovies();
        return Ok(moviesResult);
    }

    [HttpGet("{movieId}")]
    [ProducesResponseType(200, Type = typeof(Movie))]
    [ProducesResponseType(400)]
    public IActionResult Get([FromRoute] int movieId)
    {
        var movieResult = _movieService.GetMovieById(movieId);
        if (movieResult.IsFailed)
        {
            return NotFound();
        }

        return Ok(movieResult.Value);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public IActionResult Post([FromBody] Movie movie)
    {
        var createdMovieResult = _movieService.SaveMovie(movie);
        if (createdMovieResult.IsFailed)
        {
            return BadRequest(createdMovieResult.Errors);
        }

        return CreatedAtAction(nameof(Post), new { id = createdMovieResult.Value.Id }, createdMovieResult.Value);
    }

    [HttpDelete("{movieId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Delete([FromRoute] int movieId)
    {
        var deleteResult = _movieService.DeleteMovie(movieId);
        if (deleteResult.IsFailed)
        {
            return NotFound(deleteResult.Errors);
        }

        return Ok();
    }

    [HttpPut("{movieId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Update([FromRoute] int movieId, [FromBody] Movie updatedMovie)
    {
        var updateResult = _movieService.UpdateMovie(movieId, updatedMovie);
        if (updateResult.IsFailed)
        {
            return NotFound(updateResult.Errors);
        }

        return Ok();
    }

    [HttpPost("{movieId}/genres/{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult AddGenreToMovie([FromRoute] int movieId, [FromRoute] int genreId)
    {
        var addGenreResult = _movieService.AddGenreToMovie(movieId, genreId);
        if (addGenreResult.IsFailed)
        {
            return NotFound(addGenreResult.Errors);
        }

        return Ok();
    }

    [HttpGet("{movieId}/genres")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
    [ProducesResponseType(400)]
    public IActionResult GetGenresByMovie([FromRoute] int movieId)
    {
        var genresResult = _movieService.GetGenresOfMovie(movieId);
        if (genresResult.IsFailed)
        {
            return NotFound(genresResult.Errors);
        }

        return Ok(genresResult.Value);
    }

    [HttpDelete("{movieId}/genres/{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult RemoveGenreFromMovie([FromRoute] int movieId, [FromRoute] int genreId)
    {
        var removeGenreResult = _movieService.RemoveGenreFromMovie(movieId, genreId);
        if (removeGenreResult.IsFailed)
        {
            return NotFound(removeGenreResult.Errors);
        }

        return Ok();
    }
}