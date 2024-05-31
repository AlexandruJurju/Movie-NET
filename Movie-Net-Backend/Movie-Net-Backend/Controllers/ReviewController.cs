using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;

namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ReviewController(IReviewService reviewService, IMapper mapper) : ControllerBase
{
    private readonly IReviewService _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));


    /// <summary>
    /// Find all the reviews
    /// </summary>
    /// <returns>List of reviews</returns>
    /// <response code="200">Successful response</response>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<ReviewDto>))]
    public async Task<IActionResult> FindAllReviewsAsync()
    {
        var reviews = _mapper.Map<List<ReviewDto>>(await _reviewService.FindAllReviewsAsync());
        return Ok(reviews);
    }

    /// <summary>
    /// Saves a new review
    /// </summary>
    /// <param name="reviewDto">The review data</param>
    [HttpPost]
    public async Task<IActionResult> SaveReviewAsync([FromBody] ReviewDto reviewDto)
    {
        var review = _mapper.Map<Review>(reviewDto);
        await _reviewService.SaveReviewAsync(review);
        return Ok();
    }

    /// <summary>
    /// Retrieves reviews of a user
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    [HttpGet("{userId}")]
    [ProducesResponseType(200, Type = typeof(List<ReviewDto>))]
    public async Task<IActionResult> FindReviewsOfUserAsync([FromRoute] int userId)
    {
        var result = await _reviewService.FindReviewsOfUserAsync(userId);

        if (result.IsFailed) return NotFound();

        return Ok(_mapper.Map<List<ReviewDto>>(result.Value));
    }

    /// <summary>
    /// Retrieves a review of a user for a specific movie
    /// </summary>
    /// <param name="userId">The ID of the user</param>
    /// <param name="movieId">The ID of the movie</param>
    [HttpGet("{userId}/{movieId}")]
    [ProducesResponseType(200, Type = typeof(ReviewDto))]
    public async Task<IActionResult> FindUserReviewForMovieAsync([FromRoute] int userId, [FromRoute] int movieId)
    {
        var result = await _reviewService.FindReviewOfUserForMovieAsync(userId, movieId);
        if (result.IsFailed) return NotFound(result.Reasons);

        return Ok(_mapper.Map<ReviewDto>(result.Value));
    }
}