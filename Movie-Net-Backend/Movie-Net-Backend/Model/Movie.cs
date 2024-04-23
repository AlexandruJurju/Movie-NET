using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Net_Backend.Model;

[Table("movie")]
public class Movie
{
    [Required] [Key] [Column("id")] public int Id { get; set; }

    [Required]
    [Column("title")]
    [MaxLength(200)]
    public string Title { get; set; }

    [Required]
    [Column("headline")]
    [MaxLength(200)]
    public string Headline { get; set; }

    [Required]
    [Column("overview")]
    [MaxLength(1000)]
    public string Overview { get; set; }

    [Column("release_date")] public DateOnly ReleaseDate { get; set; }

    [Column("poster_url")]
    [MaxLength(200)]
    public string PosterUrl { get; set; }

    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();

    public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
}