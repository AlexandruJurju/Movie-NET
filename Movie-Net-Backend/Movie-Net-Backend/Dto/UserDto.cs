using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class UserDto
{
    [Required]
    public int Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
}