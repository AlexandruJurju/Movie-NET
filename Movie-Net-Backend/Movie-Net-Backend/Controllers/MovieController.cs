using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;
    private readonly ILogger<MovieController> _logger;

    public MovieController(IMovieService movieService, ILogger<MovieController> logger)
    {
        _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]
    public IActionResult FindAllMovies()
    {
        var movies = _movieService.FindAllMovies();
        return Ok(movies);
    }

    [HttpGet("{movieId}")]
    [ProducesResponseType(200, Type = typeof(Movie))]
    [ProducesResponseType(400)]
    public IActionResult FindMovieById([FromRoute] int movieId)
    {
        var movieResult = _movieService.FindMovieById(movieId);
        if (movieResult.IsFailed)
        {
            return NotFound();
        }

        return Ok(movieResult.Value);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    public IActionResult SaveMovie([FromBody] Movie movie)
    {
        var createdMovieResult = _movieService.SaveMovie(movie);
        if (createdMovieResult.IsFailed)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(SaveMovie), new { id = createdMovieResult.Value.Id }, createdMovieResult.Value);
    }

    [HttpDelete("{movieId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult DeleteMovie([FromRoute] int movieId)
    {
        var deleteResult = _movieService.DeleteMovie(movieId);
        if (deleteResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPut("{movieId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult UpdateMovie([FromRoute] int movieId, [FromBody] Movie updatedMovie)
    {
        var updateResult = _movieService.UpdateMovie(movieId, updatedMovie);
        if (updateResult.IsFailed)
        {
            return NotFound();
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
            return NotFound();
        }

        return Ok();
    }

    [HttpGet("{movieId}/genres")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
    [ProducesResponseType(400)]
    public IActionResult GetGenresOfMovie([FromRoute] int movieId)
    {
        var genres = _movieService.GetGenresOfMovie(movieId);

        if (genres.IsFailed)
        {
            return BadRequest();
        }

        return Ok(genres.Value);
    }

    [HttpDelete("{movieId}/genres/{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult RemoveGenreFromMovie([FromRoute] int movieId, [FromRoute] int genreId)
    {
        var removeGenreResult = _movieService.RemoveGenreFromMovie(movieId, genreId);
        if (removeGenreResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }
    
    // TODO: use MovieActorDto, remove ? from Movie and Actor in MovieActor
    [HttpPost("{movieId}/actors")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult AddActorToMovie([FromRoute] int movieId, [FromBody] MovieActor movieActor)
    {
        if (movieId != movieActor.MovieId)
        {
            return BadRequest();
        }

        var addActorResult = _movieService.AddActorToMovie(movieActor);

        if (addActorResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("{movieId}/actors/{actorId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult RemoveActorFromMovie([FromRoute] int movieId, [FromRoute] int actorId)
    {
        var removeActorResult = _movieService.RemoveActorFromMovie(movieId, actorId);
        if (removeActorResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpGet("{movieId}/actors")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Actor>))]
    [ProducesResponseType(400)]
    public IActionResult GetActorsInMovie([FromRoute] int movieId)
    {
        var movieActors = _movieService.GetActorsOfMovie(movieId);

        if (movieActors.IsFailed)
        {
            return BadRequest();
        }

        return Ok(movieActors.Value);
    }
}