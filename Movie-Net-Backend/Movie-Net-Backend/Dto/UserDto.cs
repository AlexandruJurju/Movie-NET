using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class UserDto
{
    [Required] public int Id { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string Username { get; set; }
    public string ProfilePictureUrl { get; set; }
}