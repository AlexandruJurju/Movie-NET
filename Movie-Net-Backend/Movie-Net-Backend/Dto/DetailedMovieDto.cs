using System.ComponentModel.DataAnnotations;

namespace Movie_Net_Backend.Dto;

public class DetailedMovieDto
{
    [Required] public int Id { get; set; }
    [Required] public string Title { get; set; }
    [Required] public string Headline { get; set; }
    [Required] public string Overview { get; set; }
    [Required] public DateOnly ReleaseDate { get; set; }
    [Required] public string PosterUrl { get; set; }
    [Required] public IEnumerable<GenreDto> Genres { get; set; }
    [Required] public IEnumerable<MovieActorDto> MovieActors { get; set; }
}