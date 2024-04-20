using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Exceptions;
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
        var genres = _genreService.GetAllGenres();
        return Ok(genres);
    }

    [HttpGet("{genreId}")]
    [ProducesResponseType(200, Type = typeof(Genre))]
    [ProducesResponseType(400)]
    public IActionResult Get([FromRoute] int genreId)
    {
        try
        {
            var genre = _genreService.GetGenreById(genreId);
            return Ok(genre);
        }
        catch (GenreNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(Genre))]
    public IActionResult Post([FromBody] Genre genre)
    {
        _genreService.SaveGenre(genre);
        return Ok(genre);
    }

    [HttpDelete("{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Delete([FromRoute] int genreId)
    {
        try
        {
            _genreService.DeleteGenre(genreId);
            return Ok();
        }
        catch (GenreNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPut("{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Update([FromRoute] int genreId, [FromBody] Genre updatedGenre)
    {
        try
        {
            _genreService.UpdateGenre(genreId, updatedGenre);
            return Ok();
        }
        catch (GenreNotFoundException)
        {
            return NotFound();
        }
    }
}