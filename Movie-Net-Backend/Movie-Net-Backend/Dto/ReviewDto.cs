namespace Movie_Net_Backend.Dto;

public class ReviewDto
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Score { get; set; }
    public int MovieId { get; set; }
    public int UserId { get; set; }
}