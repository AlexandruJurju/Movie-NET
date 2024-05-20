﻿using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class MovieDto
{
    [Required] public int Id { get; set; }
    [Required] public string Title { get; set; }
    [Required] public string Headline { get; set; }
    [Required] public string Overview { get; set; }
    public int RuntimeInMinutes { get; set; }
    [Required] public DateOnly ReleaseDate { get; set; }
    [Required] public string PosterUrl { get; set; }
}