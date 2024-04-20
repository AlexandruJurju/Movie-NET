using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Repository;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MovieController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public MovieController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    [HttpGet]
    public IActionResult Get()
    {
        var movies = _appDbContext.Movies.ToList();
        return Ok(movies);
    }
}