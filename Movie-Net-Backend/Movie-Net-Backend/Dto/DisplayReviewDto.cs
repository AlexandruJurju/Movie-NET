namespace Movie_Net_Backend.Dto;

public class DisplayReviewDto
{
    public string Text { get; set; }
    public int Score { get; set; }
    public UserDto User { get; set; }
}