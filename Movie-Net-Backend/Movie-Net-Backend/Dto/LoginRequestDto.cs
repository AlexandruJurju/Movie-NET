﻿using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}