using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class DisplayReviewDto
{
    [Required] public string Text { get; set; }
    [Required] public int Score { get; set; }
    [Required] public UserDto User { get; set; }
}