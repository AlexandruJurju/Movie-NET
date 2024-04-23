namespace Movie_Net_Backend.Dto;

public class MovieActorDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int ActorId { get; set; }
    public string Role { get; set; }
    public int DisplayOrder { get; set; }
}