using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Data;
using Movie_Net_Backend.Service.Interfaces;

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
    public IActionResult Get()
    {
        var movies = _movieService.GetAllMovies();
        return Ok(movies);
    }
}