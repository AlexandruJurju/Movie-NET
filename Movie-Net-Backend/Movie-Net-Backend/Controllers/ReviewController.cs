using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movie_Net_Backend.Dto;
using Movie_Net_Backend.Model;
using Movie_Net_Backend.Service.Interface;


namespace Movie_Net_Backend.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;


    public ReviewController(IReviewService reviewService, IMapper mapper)
    {
        _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<ReviewDto>))]
    public IActionResult FindAllReviews()
    {
        var movies = _mapper.Map<List<ReviewDto>>(_reviewService.FindAllReviews());
        return Ok(movies);
    }

    [HttpPost]
    public IActionResult SaveReview([FromBody] ReviewDto reviewDto)
    {
        var review = _mapper.Map<Review>(reviewDto);
        var createdReview = _reviewService.SaveReview(review);
        return CreatedAtAction(nameof(SaveReview), new { id = createdReview.Id });
    }
    
    
}