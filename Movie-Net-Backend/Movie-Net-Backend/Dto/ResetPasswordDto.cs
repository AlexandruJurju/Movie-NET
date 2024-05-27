using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class ResetPasswordDto
{
    [Required] public int UserId { get; set; }
    [Required] public string NewPassword { get; set; }
}