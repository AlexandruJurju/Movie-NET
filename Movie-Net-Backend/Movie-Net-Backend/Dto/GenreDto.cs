using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class GenreDto
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; }
}