using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class RegisterRequestDto
{
    [Required(ErrorMessage = "Username is required")]
    [MaxLength(100)]
    public string Username { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    [MaxLength(100)]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MaxLength(100)]
    public string Password { get; set; }
}