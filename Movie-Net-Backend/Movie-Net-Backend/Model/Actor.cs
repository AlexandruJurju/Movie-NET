using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Movie_Net_Backend.Model;

[Table("actor")]
public class Actor
{
    [Required] [Key] public int Id { get; set; }
    [Column("first_name")] public string FirstName { get; set; }
    [Column("last_name")] public string LastName { get; set; }
    [Column("birth_date")] public DateOnly BirthDate { get; set; }
    [Column("biography")] public string Biography { get; set; }
    [Column("profile_picture_url")] public string ProfilePictureUrl { get; set; }
    [JsonIgnore] public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
}