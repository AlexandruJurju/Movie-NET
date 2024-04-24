using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class ActorDto
{
    [Required]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Biography { get; set; }
    public string ProfilePictureUrl { get; set; }
}