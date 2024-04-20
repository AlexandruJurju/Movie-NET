using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interfaces;

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
        var genre = _genreService.GetGenreById(genreId);

        if (genre == null)
        {
            return NotFound();
        }

        return Ok(genre);
    }

    [HttpPost]
    [ProducesResponseType(200,Type=typeof(Genre))]
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
        var genre = _genreService.GetGenreById(genreId);

        if (genre == null)
        {
            return NotFound();
        }

        _genreService.DeleteGenre(genre);
        return Ok();
    }

    [HttpPut("{genreId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult Update([FromRoute] int genreId, [FromBody] Genre updatedGenre)
    {
        var existingGenre = _genreService.GetGenreById(genreId);
        if (existingGenre == null)
        {
            return NotFound();
        }

        existingGenre.Name = updatedGenre.Name;

        _genreService.UpdateGenre(existingGenre);

        return Ok();
    }
}