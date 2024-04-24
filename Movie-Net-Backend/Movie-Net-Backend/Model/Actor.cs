using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Net_Backend.Model;

[Table("actor")]
public class Actor
{
    [Key] [Required] public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Biography { get; set; }
    public string ProfilePictureUrl { get; set; }
    public virtual ICollection<MovieActor> MovieActors { get; set; }
}