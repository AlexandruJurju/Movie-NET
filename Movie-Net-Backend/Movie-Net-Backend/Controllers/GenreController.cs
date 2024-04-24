using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;
    private readonly IMapper _mapper;

    public GenreController(IGenreService genreService, IMapper mapper)
    {
        _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult FindAllGenres()
    {
        var genres = _mapper.Map<List<GenreDto>>(_genreService.GetAllGenres());
        return Ok(genres);
    }

    [HttpGet("{genreId}")]
    public IActionResult FindGenreById([FromRoute] int genreId)
    {
        var genreResult = _genreService.GetGenreById(genreId);
        if (genreResult.IsFailed)
        {
            return NotFound();
        }

        var genre = _mapper.Map<GenreDto>(genreResult.Value);

        return Ok(genre);
    }

    [HttpPost]
    public IActionResult SaveGenre([FromBody] GenreDto genreDto)
    {
        var genre = _mapper.Map<Genre>(genreDto);
        var createdGenre = _genreService.SaveGenre(genre);
        return CreatedAtAction(nameof(SaveGenre), new { id = createdGenre.Id });
    }

    [HttpDelete("{genreId}")]
    public IActionResult DeleteGenre([FromRoute] int genreId)
    {
        var deleteResult = _genreService.DeleteGenre(genreId);
        if (deleteResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPut("{genreId}")]
    public IActionResult UpdateGenre([FromRoute] int genreId, [FromBody] GenreDto updatedGenre)
    {
        if (genreId != updatedGenre.Id)
        {
            return BadRequest(ModelState);
        }

        var genre = _mapper.Map<Genre>(updatedGenre);

        var updateResult = _genreService.UpdateGenre(genreId, genre);
        if (updateResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpGet("{genreId}/movies")]
    public IActionResult GetMoviesWithGenre([FromRoute] int genreId)
    {
        var moviesResult = _genreService.GetMoviesWithGenre(genreId);
        if (moviesResult.IsFailed)
        {
            return NotFound();
        }

        var movies = _mapper.Map<List<Movie>>(moviesResult.Value);
        return Ok(movies);
    }
}