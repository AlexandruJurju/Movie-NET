using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;


namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;
    private readonly IMapper _mapper;

    public MovieController(IMovieService movieService, IMapper mapper)
    {
        _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<MovieDto>))]
    public IActionResult FindAllMovies()
    {
        var movies = _mapper.Map<List<MovieDto>>(_movieService.FindAllMovies());
        return Ok(movies);
    }

    [HttpGet("{movieId}")]
    [ProducesResponseType(200, Type = typeof(DetailedMovieDto))]
    public IActionResult FindMovieById([FromRoute] int movieId)
    {
        var result = _movieService.FindMovieById(movieId);
        if (result.IsFailed) return NotFound();

        var movie = _mapper.Map<DetailedMovieDto>(result.Value);

        return Ok(movie);
    }

    [HttpGet("{page}/{size}")]
    [ProducesResponseType(200, Type = typeof(PageResponse<MovieDto>))]
    public IActionResult FindAllMoviesPages([FromRoute] int page, [FromRoute] int size)
    {
        var movies = _mapper.Map<List<MovieDto>>(_movieService.FindAllMovies());
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
    public IActionResult SaveMovie([FromBody] MovieDto movieDto)
    {
        var movie = _mapper.Map<Movie>(movieDto);
        var createdMovie = _movieService.SaveMovie(movie);
        return CreatedAtAction(nameof(SaveMovie), new { id = createdMovie.Id });
    }

    [HttpDelete("{movieId}")]
    public IActionResult DeleteMovie([FromRoute] int movieId)
    {
        var deleteResult = _movieService.DeleteMovie(movieId);
        if (deleteResult.IsFailed) return NotFound();

        return Ok();
    }

    [HttpPut("{movieId}")]
    public IActionResult UpdateMovie([FromRoute] int movieId, [FromBody] MovieDto updatedMovie)
    {
        if (movieId != updatedMovie.Id) return BadRequest(ModelState);

        var movie = _mapper.Map<Movie>(updatedMovie);

        var updateResult = _movieService.UpdateMovie(movieId, movie);
        if (updateResult.IsFailed) return NotFound();

        return Ok();
    }

    [HttpPost("{movieId}/genres/{genreId}")]
    public IActionResult AddGenreToMovie([FromRoute] int movieId, [FromRoute] int genreId)
    {
        var addGenreResult = _movieService.AddGenreToMovie(movieId, genreId);
        if (addGenreResult.IsFailed) return NotFound();

        return Ok();
    }

    [HttpGet("{movieId}/genres")]
    public IActionResult GetGenresOfMovie([FromRoute] int movieId)
    {
        var result = _movieService.GetGenresOfMovie(movieId);

        if (result.IsFailed) return BadRequest();

        var genres = _mapper.Map<List<GenreDto>>(result.Value);


        return Ok(genres);
    }

    [HttpDelete("{movieId}/genres/{genreId}")]
    public IActionResult RemoveGenreFromMovie([FromRoute] int movieId, [FromRoute] int genreId)
    {
        var removeGenreResult = _movieService.RemoveGenreFromMovie(movieId, genreId);
        if (removeGenreResult.IsFailed) return NotFound();

        return Ok();
    }
}