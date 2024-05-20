using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class ActorDto
{
    [Required] public int Id { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public DateOnly BirthDate { get; set; }
    [Required] public string Biography { get; set; }
    [Required] public string ProfilePictureUrl { get; set; }
}