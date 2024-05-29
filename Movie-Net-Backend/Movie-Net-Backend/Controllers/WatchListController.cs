using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class WatchListController : ControllerBase
{
    private readonly IWatchlistService _watchlistService;
    private readonly IMapper _mapper;

    public WatchListController(IWatchlistService watchlistService, IMapper mapper)
    {
        _watchlistService = watchlistService;
        _mapper = mapper;
    }

    /// <summary>
    /// Adds a movie to a user's watchlist
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <param name="movieId">The ID of the movie</param>

    [HttpPost("{userId}/watchlist/{movieId}")]
    [ProducesResponseType(200)]
    public IActionResult AddMovieToWatchlist([FromRoute] int userId, [FromRoute] int movieId)
    {
        var result = _watchlistService.AddMovieToWatchlist(userId, movieId);
        if (result.IsFailed) return NotFound(result.Errors);

        return Ok();
    }

    [HttpDelete("{userId}/watchlist/{movieId}")]
    [ProducesResponseType(200)]
    public IActionResult RemoveMovieFromWatchlist([FromRoute] int userId, [FromRoute] int movieId)
    {
        var result = _watchlistService.RemoveMovieFromWatchlist(userId, movieId);
        if (result.IsFailed) return NotFound(result.Errors);

        return Ok();
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(200, Type = typeof(List<MovieDto>))]
    public IActionResult FindUserWatchlist([FromRoute] int userId)
    {
        var result = _watchlistService.FindWatchlistOfUser(userId);
        if (result.IsFailed) return NotFound(result.Errors);

        return Ok(_mapper.Map<List<MovieDto>>(result.Value));
    }
}