using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Net_Backend.Model;

[Table("movie")]
public class Movie
{
    [Key] [Required] public int Id { get; set; }
    public string Title { get; set; }
    public string Headline { get; set; }
    public string Overview { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string PosterUrl { get; set; }
    public virtual ICollection<Genre> Genres { get; set; }
    public virtual ICollection<MovieActor> MovieActors { get; set; }
}