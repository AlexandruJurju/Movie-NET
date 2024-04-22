using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Movie_Net_Backend.Model;

[Table("movie")]
public class Movie
{
    [Required] [Key] [Column("id")] public int Id { get; set; }

    [Required]
    [Column("title")]
    [MaxLength(200)]
    public string Title { get; set; } = String.Empty;

    [Required]
    [Column("headline")]
    [MaxLength(200)]
    public string Headline { get; set; } = String.Empty;

    [Required]
    [Column("overview")]
    [MaxLength(1000)]
    public string Overview { get; set; } = String.Empty;

    [Column("release_date")] public DateOnly ReleaseDate { get; set; }

    [Column("poster_url")]
    [MaxLength(200)]
    public string PosterUrl { get; set; } = String.Empty;

    [JsonIgnore] public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
    
    [JsonIgnore] public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
}