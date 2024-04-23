namespace Movie_Net_Backend.Dto;

public class MovieDto
{
    int Id { get; set; }
    public string Title { get; set; }
    public string Headline { get; set; }
    public string Overview { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string PosterUrl { get; set; }
}