using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GenreController(IGenreService genreService, IMapper mapper) : ControllerBase
{
    private readonly IGenreService _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<GenreDto>))]
    public async Task<IActionResult> FindAllGenresAsync()
    {
        var genres = _mapper.Map<List<GenreDto>>(await _genreService.GetAllGenresAsync());
        return Ok(genres);
    }

    [HttpGet("{genreId}")]
    [ProducesResponseType(200, Type = typeof(GenreDto))]
    public async Task<IActionResult> FindGenreByIdAsync([FromRoute] int genreId)
    {
        var genreResult = await _genreService.GetGenreByIdAsync(genreId);
        if (genreResult.IsFailed) return NotFound();

        var genre = _mapper.Map<GenreDto>(genreResult.Value);
        return Ok(genre);
    }

    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<IActionResult> SaveGenreAsync([FromBody] GenreDto genreDto)
    {
        var genre = _mapper.Map<Genre>(genreDto);
        var createdGenre = await _genreService.SaveGenreAsync(genre);
        return CreatedAtAction(nameof(SaveGenreAsync), new { id = createdGenre.Id });
    }

    [HttpDelete("{genreId}")]
    public async Task<IActionResult> DeleteGenreAsync([FromRoute] int genreId)
    {
        var deleteResult = await _genreService.DeleteGenreAsync(genreId);
        if (deleteResult.IsFailed) return NotFound();

        return Ok();
    }

    [HttpPut("{genreId}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> UpdateGenreAsync([FromRoute] int genreId, [FromBody] GenreDto updatedGenre)
    {
        if (genreId != updatedGenre.Id) return BadRequest();

        var genre = _mapper.Map<Genre>(updatedGenre);

        var updateResult = await _genreService.UpdateGenreAsync(genreId, genre);
        if (updateResult.IsFailed) return NotFound();

        return Ok();
    }

    [HttpGet("{genreId}/movies")]
    [ProducesResponseType(200, Type = typeof(List<MovieDto>))]
    public async Task<IActionResult> GetMoviesWithGenreAsync([FromRoute] int genreId)
    {
        var moviesResult = await _genreService.GetMoviesWithGenreAsync(genreId);
        if (moviesResult.IsFailed) return NotFound();

        var movies = _mapper.Map<List<MovieDto>>(moviesResult.Value);
        return Ok(movies);
    }
}