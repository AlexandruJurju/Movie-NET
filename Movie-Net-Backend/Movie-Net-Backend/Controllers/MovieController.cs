using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    private readonly ILogger<MovieController> _logger;
    private readonly IMapper _mapper;

    public MovieController(IMovieService movieService, ILogger<MovieController> logger, IMapper mapper)
    {
        _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult FindAllMovies()
    {
        var movies = _mapper.Map<List<MovieDto>>(_movieService.FindAllMovies());
        return Ok(movies);
    }

    [HttpGet("{movieId}")]
    public IActionResult FindMovieById([FromRoute] int movieId)
    {
        var result = _movieService.FindMovieById(movieId);
        if (result.IsFailed)
        {
            return NotFound();
        }

        var movie = _mapper.Map<MovieDto>(result.Value);

        return Ok(movie);
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
        if (deleteResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPut("{movieId}")]
    public IActionResult UpdateMovie([FromRoute] int movieId, [FromBody] MovieDto updatedMovie)
    {
        if (movieId != updatedMovie.Id)
        {
            return BadRequest(ModelState);
        }

        var movie = _mapper.Map<Movie>(updatedMovie);

        var updateResult = _movieService.UpdateMovie(movieId, movie);
        if (updateResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPost("{movieId}/genres/{genreId}")]
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
    public IActionResult GetGenresOfMovie([FromRoute] int movieId)
    {
        var result = _movieService.GetGenresOfMovie(movieId);

        if (result.IsFailed)
        {
            return BadRequest();
        }

        var genres = _mapper.Map<List<GenreDto>>(result.Value);


        return Ok(genres);
    }

    [HttpDelete("{movieId}/genres/{genreId}")]
    public IActionResult RemoveGenreFromMovie([FromRoute] int movieId, [FromRoute] int genreId)
    {
        var removeGenreResult = _movieService.RemoveGenreFromMovie(movieId, genreId);
        if (removeGenreResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpPost("{movieId}/actors")]
    public IActionResult AddActorToMovie([FromRoute] int movieId, [FromBody] MovieActorDto movieActorDto)
    {
        if (movieId != movieActorDto.MovieId)
        {
            return BadRequest();
        }

        var movieActor = _mapper.Map<MovieActor>(movieActorDto);

        var addActorResult = _movieService.AddActorToMovie(movieActor);

        if (addActorResult.IsFailed)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("{movieId}/actors/{actorId}")]
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
    public IActionResult GetActorsInMovie([FromRoute] int movieId)
    {
        var movieActors = _movieService.GetActorsOfMovie(movieId);

        if (movieActors.IsFailed)
        {
            return BadRequest();
        }

        var actors = _mapper.Map<List<ActorDto>>(movieActors.Value);

        return Ok(actors);
    }
}