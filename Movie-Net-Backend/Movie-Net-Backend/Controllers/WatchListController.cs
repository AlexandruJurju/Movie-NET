using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class WatchListController(IWatchlistService watchlistService, IMapper mapper) : ControllerBase
{
    private readonly IWatchlistService _watchlistService = watchlistService ?? throw new ArgumentNullException(nameof(watchlistService));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    [HttpPost("{userId}/watchlist/{movieId}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> AddMovieToWatchlistAsync([FromRoute] int userId, [FromRoute] int movieId)
    {
        var result = await _watchlistService.AddMovieToWatchlistAsync(userId, movieId);
        if (result.IsFailed) return NotFound(result.Errors);

        return Ok();
    }

    [HttpDelete("{userId}/watchlist/{movieId}")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> RemoveMovieFromWatchlistAsync([FromRoute] int userId, [FromRoute] int movieId)
    {
        var result = await _watchlistService.RemoveMovieFromWatchlistAsync(userId, movieId);
        if (result.IsFailed) return NotFound(result.Errors);

        return Ok();
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(200, Type = typeof(List<MovieDto>))]
    public async Task<IActionResult> FindUserWatchlistAsync([FromRoute] int userId)
    {
        var result = await _watchlistService.FindWatchlistOfUserAsync(userId);
        if (result.IsFailed) return NotFound(result.Errors);

        return Ok(_mapper.Map<List<MovieDto>>(result.Value));
    }
}