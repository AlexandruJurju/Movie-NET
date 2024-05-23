using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class ReviewDto
{
    [Required] public int Id { get; set; }
    [Required] public string Text { get; set; }
    [Required] public int Score { get; set; }
    [Required] public int MovieId { get; set; }
    [Required] public int UserId { get; set; }
}