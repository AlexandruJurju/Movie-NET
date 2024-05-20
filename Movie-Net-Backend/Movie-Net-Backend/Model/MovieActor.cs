using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Movie_Net_Backend.Model;

[Table("movie_actor")]
public class MovieActor
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("role")]
    public string Role { get; set; }
    [Column("display_order")]
    public int DisplayOrder { get; set; }

    [Column("movie_id")]
    public int MovieId { get; set; }
    [Column("actor_id")]
    public int ActorId { get; set; }

    public virtual Movie? Movie { get; set; }
    public virtual Actor? Actor { get; set; }
}