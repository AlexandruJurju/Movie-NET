using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/v1/[controller]")]
public class MovieController(IMovieService movieService, IMapper mapper) : ControllerBase
{
    private readonly IMovieService _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<MovieDto>))]
    public IActionResult FindAllMovies()
    {
        var movies = _mapper.Map<List<MovieDto>>(_movieService.FindAllMoviesAsync());
        return Ok(movies);
    }

    // todo: response code when not found
    [HttpGet("{movieId}")]
    [ProducesResponseType(200, Type = typeof(DetailedMovieDto))]
    public async Task<IActionResult> FindMovieById([FromRoute] int movieId)
    {
        var result = await _movieService.FindMovieByIdAsync(movieId);
        if (result.IsFailed) return NotFound();

        var movie = _mapper.Map<DetailedMovieDto>(result.Value);

        return Ok(movie);
    }

    [HttpGet("{page}/{size}")]
    [ProducesResponseType(200, Type = typeof(PageResponse<MovieDto>))]
    public async Task<IActionResult> FindAllMoviesPages([FromRoute] int page, [FromRoute] int size)
    {
        var movies = _mapper.Map<List<MovieDto>>(await _movieService.FindAllMoviesAsync());
        var totalElements = movies.Count();
        var totalPages = (int)Math.Ceiling((double)totalElements / size);
        var content = movies.Skip((page - 1) * size).Take(size).ToList();
        PageResponse<MovieDto> response = new PageResponse<MovieDto>
        {
            Content = content,
            Number = page,
            Size = size,
            TotalElements = totalElements,
            TotalPages = totalPages,
            First = page == 1,
            Last = page == totalPages
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> SaveMovie([FromBody] MovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);
        var createdMovie = await _movieService.SaveMovieAsync(movie);
        return CreatedAtAction(nameof(SaveMovie), new { id = createdMovie.Id });
    }

    [HttpDelete("{movieId}")]
    public async Task<IActionResult> DeleteMovie([FromRoute] int movieId)
    {
        var deleteResult = await _movieService.DeleteMovieAsync(movieId);
        if (deleteResult.IsFailed) return NotFound();

        return Ok();
    }

    [HttpPut("{movieId}")]
    public async Task<IActionResult> UpdateMovie([FromRoute] int movieId, [FromBody] MovieDto updatedMovie)
    {
        if (movieId != updatedMovie.Id) return BadRequest(ModelState);

        var movie = _mapper.Map<Movie>(updatedMovie);

        var updateResult = await _movieService.UpdateMovieAsync(movieId, movie);
        if (updateResult.IsFailed) return NotFound();

        return Ok();
    }

    /// <summary>
    /// Find movies with a specific genre
    /// </summary>
    /// <param name="genreId">The ID of the genre to filter movies by</param>
    /// <returns>A list of movies belonging to the specified genre</returns>
    /// <response code="200">Successful response</response>
    [HttpGet("genre/{genreId}")]
    [ProducesResponseType(200, Type = typeof(List<MovieDto>))]
    public async Task<IActionResult> FindMoviesWithGenre([FromRoute] int genreId)
    {
        var moviesWithGenre = await _movieService.FindMoviesWithGenreAsync(genreId);

        return Ok(_mapper.Map<List<MovieDto>>(moviesWithGenre));
    }
}