using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class MovieActorDto
{
    [Required] public int Id { get; set; }
    [Required] public ActorDto Actor { get; set; }
    [Required] public string Role { get; set; }
    [Required] public int displayOrder { get; set; }
    [Required] public string CharacterImageUrl { get; set; }
}