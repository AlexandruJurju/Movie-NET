using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Genre>))]
    public IActionResult Get()
    {
        var genresResult = _genreService.GetAllGenres();
        return Ok(genresResult);
    }

    [HttpGet("{genreId}")]
    [ProducesResponseType(200, Type = typeof(Genre))]
    [ProducesResponseType(400)]
    public IActionResult Get([FromRoute] int genreId)
    {
        var genreResult = _genreService.GetGenreById(genreId);
        if (genreResult.IsFailed)
        {
            return NotFound();
        }

        return Ok(genreResult.Value);
    }

    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Genre))]
    public IActionResult Post([FromBody] Genre genre)
    {
        var createdGenreResult = _genreService.SaveGenre(genre);
        if (createdGenreResult.IsFailed)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Post), new { id = createdGenreResult.Value.Id }, createdGenreResult.Value);
    }

    [HttpDelete("{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Delete([FromRoute] int genreId)
    {
        var deleteResult = _genreService.DeleteGenre(genreId);
        if (deleteResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPut("{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Update([FromRoute] int genreId, [FromBody] Genre updatedGenre)
    {
        var updateResult = _genreService.UpdateGenre(genreId, updatedGenre);
        if (updateResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpGet("{genreId}/movies")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]
    [ProducesResponseType(400)]
    public IActionResult GetMoviesByGenre([FromRoute] int genreId)
    {
        var moviesResult = _genreService.GetMoviesWithGenre(genreId);
        if (moviesResult.IsFailed)
        {
            return NotFound();
        }

        return Ok(moviesResult.Value);
    }
}
