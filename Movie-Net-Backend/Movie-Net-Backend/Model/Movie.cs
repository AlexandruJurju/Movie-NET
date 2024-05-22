using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Net_Backend.Model;

[Table("movie")]
public class Movie
{
    [Key] [Column("id")] public int Id { get; set; }
    [Column("title")] public string Title { get; set; }
    [Column("headline")] public string Headline { get; set; }
    [Column("overview")] public string Overview { get; set; }
    [Column("release_date")] public DateOnly ReleaseDate { get; set; }
    [Column("poster_url")] public string PosterUrl { get; set; }
    public virtual ICollection<Genre> Genres { get; set; }
    public virtual ICollection<MovieActor> MovieActors { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<User> Users { get; set; }
}